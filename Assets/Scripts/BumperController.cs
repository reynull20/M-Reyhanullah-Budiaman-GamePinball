using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider ball;
    public float multiplier;

    [SerializeField]
    [Tooltip("Point to be added to final score when hitted")]
    private float point = 10;

    // Animation
    private Animator animator;

    public AudioManager audioManager;
    public VFXManager vFXManager;
    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider == ball)
        {
            Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();
            ballRigidBody.velocity *= multiplier;
            
            animator.SetTrigger("hit");

            audioManager.PlaySFX(other.transform.position);
            vFXManager.PlayVFX(other.transform.position);

            // Add Score
            scoreManager.AddScore(point);
        }
    }
}
