using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadingBackground : MonoBehaviour
{
    public GameObject environmentFadeables = default;
    public Image background = default;

    void Start() {
        background.DOFade(0f, 0.001f);
    }

    public void toggleBackground(bool turnOn) {

    }
}
