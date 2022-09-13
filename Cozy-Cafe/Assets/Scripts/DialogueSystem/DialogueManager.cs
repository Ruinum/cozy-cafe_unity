using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Cozy_Cafe;
using Articy.Unity;
using Articy.Unity.Interfaces;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks {
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI personName;
    [SerializeField] private RectTransform branchingPanel;

    public static DialogueManager Singletone;
    public bool DialogueBoxActive { get; set; }

    private ArticyFlowPlayer flowPlayer;

    private void Awake() {
        Singletone = this;
        flowPlayer = GetComponent<ArticyFlowPlayer>();
    }

    public void StartDialogue(IArticyObject aObject) {
        if (aObject == null) return;
        DialogueBoxActive = true;
        dialogueBox.SetActive(DialogueBoxActive);

        flowPlayer.StartOn = aObject;
    }

    public void CloseDialogueBox() {
        DialogueBoxActive = false;
        dialogueBox.SetActive(DialogueBoxActive);
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

        if (dialogueIsFinished) return;

        foreach (var branch in aBranches) {
            var button = Instantiate(Resources.Load<GameObject>("Prefabs/Dialogue Branch"), branchingPanel);
        }
    }

    private void ClearBranches() {
        foreach (Transform child in branchingPanel) {
            Destroy(child.gameObject);
        }
    }
}