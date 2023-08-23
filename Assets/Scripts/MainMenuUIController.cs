using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playGameButton;
    public Button exitButton;
    public Button creditButton;

    private void Start() 
    {
        playGameButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(Exit);
        creditButton.onClick.AddListener(OpenCreditMenu);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenCreditMenu()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
