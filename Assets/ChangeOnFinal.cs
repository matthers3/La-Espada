using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeOnFinal : MonoBehaviour
{
    private DialogueCommands dialogueCommands;
    private bool triggered = false;
    public UnityEvent triggerEvent = default;

    void Start()
    {
        dialogueCommands = FindObjectOfType<DialogueCommands>();
    }

    void Update()
    {
        if (!triggered && dialogueCommands.allClues()) {
            print("CHANGE!");
            triggered = true;
            triggerEvent.Invoke();
        }
    }
}
