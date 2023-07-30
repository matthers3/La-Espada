using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinalFade : MonoBehaviour
{
    public bool gameFinished = false;
    public GameObject EndMessage;

    void Start() {
        StartCoroutine(startGame());
    }

    private IEnumerator startGame() {
        yield return new WaitForSeconds(1f);
        GetComponent<CanvasGroup>().DOFade(0f, 1f)
            .OnComplete(() => FindObjectOfType<RaySelector>().playerReady = true);
    }

    public void End() {
        gameFinished = true;
        StartCoroutine(endTitleAndCredits());
    }

    IEnumerator endTitleAndCredits() {
        yield return new WaitForSeconds(1.25f);
        GetComponent<CanvasGroup>().DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);
        EndMessage.SetActive(true);
    }
}
