using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDropdownValue : MonoBehaviour
{

    void Awake()
    {
        LocalizedMenu config = FindObjectOfType<LocalizedMenu>();
        TMP_Dropdown dropdown = FindObjectOfType<TMP_Dropdown>();

        if (config.CURRENT_LOCALE == "es") {
            dropdown.value = 0;
        } else {
            dropdown.value = 1;
        }
    }

}
