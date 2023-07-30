using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{

    private double positives = 0.0;
    private double negatives = 0.0;
    private double sword = 0.0;

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
        positives += 1.0;
        checkEnd();
    }

    [YarnCommand("sum_negative")]
    public void SumNegative() {
        negatives += 1.0;
        checkEnd();
    }

    [YarnCommand("sum_sword")]
    public void SumSword() {
        sword += 1.0;
    }

    private void checkEnd() {

        if (endSequenceSet) {
            return;
        }

        if (!allClues()) {
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

    public bool allClues() {
        return positives + negatives >= 1;
    }

    [YarnCommand("trigger_final")]
    public void TriggerFinal() {
        double total = positives + negatives + sword;
        if (total <= 2.0) { 
            StartCoroutine(startFinalDialogue("MirrorStart"));
        } else if (total <= 4.0) {
            StartCoroutine(startFinalDialogue("MirrorMid"));
        } else {
            FindObjectOfType<RaySelector>().enabled = false;
            double goodChance = positives / 4.0;
            float actualChance = Random.Range(0.0f, 1.0f);
            if (goodChance >= actualChance) {
                StartCoroutine(startFinalDialogue("MirrorFinaleGood"));
            } else {
                StartCoroutine(startFinalDialogue("MirrorFinaleNegation"));
            }
        }
    }

    IEnumerator startFinalDialogue(string path) {
        yield return new WaitForEndOfFrame();
        FindObjectOfType<DialogueRunner>().StartDialogue(path);
    }

    [YarnCommand("liberate_player")]
    public void liberatePlayer() {
        FindObjectOfType<RaySelector>().inspecting = false;
    }

    [YarnCommand("end_game")]
    public void EndGame() {
        FindObjectOfType<FinalFade>().End();
    }

}
