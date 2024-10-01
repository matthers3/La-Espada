using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OptionTextGetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        FindObjectOfType<TextLineProvider>().textLanguageCode = FindObjectOfType<LocalizedMenu>().CURRENT_LOCALE;
    }

    void Update() {
        FindObjectOfType<TextLineProvider>().textLanguageCode = FindObjectOfType<LocalizedMenu>().CURRENT_LOCALE;
    }
}
