using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks {
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI personName;
    
    public static DialogueManager Singletone;
    public bool DialogueBoxActive { get; set; }

    private ArticyFlowPlayer flowPlayer;

    private void Awake() {
        Singletone = this;
        flowPlayer = GetComponent<ArticyFlowPlayer>();
    }

    public void StartDialogue() {
        DialogueBoxActive = true;
        dialogueBox.SetActive(DialogueBoxActive);
    }

    public void CloseDialogueBox() {
        DialogueBoxActive = false;
        dialogueBox.SetActive(DialogueBoxActive);
    }

    public void OnFlowPlayerPaused(IFlowObject aObject) {
        dialogueText.text = string.Empty;

        if (aObject is IObjectWithText objectWithText) dialogueText.text = objectWithText.Text;
    }

    public void OnBranchesUpdated(IList<Branch> aBranches) {
        throw new NotImplementedException();
    }
}