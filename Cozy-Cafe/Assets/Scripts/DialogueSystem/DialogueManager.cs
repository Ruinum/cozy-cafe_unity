using System.Collections.Generic;
using Articy.Cozy_Cafe;
using Articy.Unity;
using Articy.Unity.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem {
    public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks {
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TextMeshProUGUI personName;
        [SerializeField] private RectTransform branchingPanel;

        // public static DialogueManager Singletone;

        private ArticyFlowPlayer flowPlayer;

        private void Awake() {
            // Singletone = this;
            flowPlayer = GetComponent<ArticyFlowPlayer>();
        }

        public void StartDialogue(IArticyObject aObject) {
            if (aObject == null) return;
            dialogueBox.SetActive(true);

            flowPlayer.StartOn = aObject;
        }

        private void CloseDialogueBox() {
            dialogueBox.SetActive(false);
        }

        public void OnFlowPlayerPaused(IFlowObject aObject) {
            dialogueText.text = string.Empty;
            personName.text = string.Empty;


            if (aObject is IObjectWithText objectWithText) dialogueText.text = objectWithText.Text;

            if (!(aObject is IObjectWithSpeaker objectWithSpeaker)) return;
            if (objectWithSpeaker.Speaker is Entity speaker) personName.text = speaker.DisplayName;
        }

        public void OnBranchesUpdated(IList<Branch> aBranches) {
            ClearBranches();

            var dialogueIsFinished = true;
            foreach (var branch in aBranches) {
                if (branch.Target is IDialogueFragment) dialogueIsFinished = false;
            }

            if (!dialogueIsFinished) {
                foreach (var branch in aBranches) {
                    var button = Instantiate(Resources.Load<GameObject>("Prefabs/Branch Button"), branchingPanel);
                    button.GetComponent<BranchSelector>().AssignBranch(flowPlayer, branch);
                }
            }
            else {
                var button = Instantiate(Resources.Load<GameObject>("Prefabs/Close Button"), branchingPanel);
                button.GetComponent<Button>().onClick.AddListener(CloseDialogueBox);
            }
        }

        private void ClearBranches() {
            foreach (Transform child in branchingPanel) {
                Destroy(child.gameObject);
            }
        }
    }
}