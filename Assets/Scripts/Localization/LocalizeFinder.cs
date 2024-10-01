using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizeFinder : MonoBehaviour
{
    public void setLocale() {
        FindObjectOfType<LocalizedMenu>().setLocale();
    }
}
