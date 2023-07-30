using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{

    private int positives = 0;
    private int negatives = 0;

    private bool didSelect = false;
    private float counter = 0f;

    private IEnumerator endCoroutine;
    private bool endSequenceSet = false;

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

    [YarnCommand("begin_interaction")]
    public void BeginInteraction(string name) {
        GameObject.Find(name).GetComponent<InspectableObject>().StartInteraction();
    }

    [YarnCommand("end_interaction")]
    public void EndInteraction(string name) {
        GameObject.Find(name).GetComponent<InspectableObject>().EndInteraction();
    }

    [YarnCommand("sum_positive")]
    public void SumPositive() {
        positives += 1;
        checkEnd();
    }

        [YarnCommand("sum_negative")]
    public void SumNegative() {
        negatives += 1;
        checkEnd();
    }

    private void checkEnd() {

        if (endSequenceSet) {
            return;
        }

        if (positives + negatives < 4) {
            return;
        }
        
        IEnumerator endTimer(float duration) {
            yield return new WaitForSeconds(duration);
            if (FindObjectOfType<DialogueRunner>().IsDialogueRunning)
            {
                StartCoroutine(endTimer(5f));
            } 
            else 
            {
                FindObjectOfType<DialogueRunner>().StartDialogue("MirrorPrompt");
            }
        }

        endSequenceSet = true;
        endCoroutine = endTimer(120f);
        StartCoroutine(endCoroutine);

    }

}
