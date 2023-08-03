using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("PanPlayground");
        //no funciona esto de abajo mati no se ojala tu caches más
        //Cursor.lockState = CursorLockMode.Locked; 
    }
    public void EndGame(){
        Application.Quit();
        //I imagine this will be changed to "back to the menu" once the three games converge
    }
}
