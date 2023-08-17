/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLanguageRuntime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DiaRun = GetComponent<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        DiaRun.TextLineProvider = CURRENT_LOCALE;
    }
}
