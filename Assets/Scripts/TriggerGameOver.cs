using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider ball;
    public ScoreManager scoreManager;
    public GameObject GameOverUI;

    private Vector3 ballSpawnPosition;

    private void Start() {
        ballSpawnPosition = ball.gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            // scoreManager.ResetScore();
            // ball.gameObject.transform.position = ballSpawnPosition;
            // SceneManager.LoadScene("Main Menu");
            GameOverUI.SetActive(true);
        }
    }
}
