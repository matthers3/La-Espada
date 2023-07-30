using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinalFade : MonoBehaviour
{
    public GameObject EndMessage;

    public void End() {
        StartCoroutine(endTitleAndCredits());
    }

    IEnumerator endTitleAndCredits() {
        yield return new WaitForSeconds(1.25f);
        GetComponent<CanvasGroup>().DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);
        EndMessage.SetActive(true);
    }
}
