using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton() 
    {
        Debug.Log("Start Clicked");
        SceneManager.LoadScene("Battleground");
    }

    public void OptionsButton()
    {
        Debug.Log("Options Clicked");
    }

    public void ExitButton()
    {
        Debug.Log("Exit Clicked");
        Application.Quit();
    }

    public void HomeButton() 
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
    }
}
