using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueRunningObserver : MonoBehaviour
{

    private CanvasGroup canvasGroup;
    private DialogueRunner dialogueRunner;

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    void Update() {
        if (dialogueRunner.IsDialogueRunning) {
            canvasGroup.alpha = 1f;
        } else {
            canvasGroup.alpha = 0f;
        }
    }
}
