using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LogoFade : MonoBehaviour
{
    public float fadeTime = 0.75f;
    
    void Start()
    {
        IEnumerator fadeSeq() {
            yield return new WaitForSeconds(fadeTime);
            GetComponent<Image>().DOFade(0f, fadeTime);
            yield return new WaitForSeconds(3 * fadeTime);
            GetComponent<Image>().DOFade(1f, fadeTime);
            yield return new WaitForSeconds(2 * fadeTime);
            StartGame();
        }
        
        StartCoroutine(fadeSeq());
    }

    public void StartGame(){
        SceneManager.LoadScene("PanPlayground_Title");
        //no funciona esto de abajo mati no se ojala tu caches más
        //Cursor.lockState = CursorLockMode.Locked; 
    }
}
