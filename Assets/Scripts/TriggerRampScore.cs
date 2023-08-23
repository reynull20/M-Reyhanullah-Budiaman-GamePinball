using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampScore : MonoBehaviour
{
    public Collider ball;
    public ScoreManager scoreManager;

    [SerializeField]
    [Tooltip("Point to be added to final score when passed")]
    private float point = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            scoreManager.AddScore(point);
        }
    }
}
