using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider ball;
    public KeyCode input;
    private new Renderer renderer;
    private Color defaultColor;
    [SerializeField]
    private Color pressedColor;
    
    [SerializeField]
    private float colorTransitionSpeed;
    public float maxTimeHold;
    public float maxForce;
    private bool isHold;

    // Start is called before the first frame update
    void Start()
    {
        isHold = false;   
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider == ball)
        {
            ReadInput(ball);
        }
    }

    private IEnumerator ChangeColorCoroutine(Color targetColor)
    {
        Color startColor = renderer.material.color;
        float t = 0;

        while (Input.GetKey(input))
        {
            t += Time.deltaTime * colorTransitionSpeed;
            renderer.material.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        renderer.material.color = startColor;
    }

    private void ReadInput(Collider other)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(other));
            StartCoroutine(ChangeColorCoroutine(pressedColor));
        }
    }

    private IEnumerator StartHold(Collider other)
    {
        float force = 0f;
        float timeHold = 0f;
        isHold = true;
        
        while (Input.GetKey(input))
        {
            // Count Force
            force = Mathf.Lerp(force, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        other.GetComponent<Rigidbody>().AddForce(Vector3.back * force);
        isHold = false;
    }
}
