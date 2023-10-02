using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LocalizedMenu : MonoBehaviour
{
    public static LocalizedMenu instance = null;
    public string CURRENT_LOCALE = "es";
    public bool localeBool = true; //español default
    //public GameObject DialogueManagerObj = GameObject.Find("DialogueManager");

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }

    }
    

    public Dictionary<string, string> spanish = new Dictionary<string, string>() {
        {"start", "Jugar"},
        {"exit", "Salir"},
        {"lang", "Idioma"}
    };
    
    public Dictionary<string, string> english = new Dictionary<string, string>() {
        {"start", "Start"},
        {"exit", "Exit"},
        {"lang", "Language"}
    };

    public string getTranslation(string key) {
        if (key != "") {
            if (CURRENT_LOCALE == "en") {
                return english[key];
            } else if (CURRENT_LOCALE == "es") {
                return spanish[key];
            } 
        }
        return "";
    }

    public void setLocale() {
        if (localeBool == false) {
            CURRENT_LOCALE = "en";
            localeBool = true;
        } else {
            CURRENT_LOCALE = "es";
            localeBool = false;
        }
    }
    
}