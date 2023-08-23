using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField]
    private ScoreManager scoreManager;

    private void Update()
    {
        scoreText.text = scoreManager.score.ToString();
    }
}
