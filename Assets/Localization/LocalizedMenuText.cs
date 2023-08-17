using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedMenuText : MonoBehaviour
{
    public string stringKey = "";

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<LocalizedMenu>().getTranslation(stringKey);
    }
}
