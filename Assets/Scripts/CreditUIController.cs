using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditUIController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
