
using UnityEngine;

using Yarn.Unity;

class SetLanguageRuntime: MonoBehaviour {

    void Start() {
        FindObjectOfType<TextLineProvider>().textLanguageCode = 
            FindObjectOfType<LocalizedMenu>().CURRENT_LOCALE;
    }

}
