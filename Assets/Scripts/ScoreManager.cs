using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;

    private void Start() {
        ResetScore();
    }
    
    public void AddScore(float increment)
    {
        score += increment;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
