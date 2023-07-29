using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{

    private bool didSelect = false;
    private float counter = 0f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            didSelect = true;
        }
        counter += Time.deltaTime;
    }

    [YarnCommand("reset_timer")]
    public void resetTimer() {
        counter = 0;
    }

    [YarnCommand("awaiting_dialogue")]
    public IEnumerator awaitingDialogue() {
        while (true) {
            didSelect = false;
            yield return new WaitForSeconds(0.1f);
            if (didSelect) {
                yield break;
            }
        // Yarn.setVariable("conversacion1", true)
        }   
    }

}
