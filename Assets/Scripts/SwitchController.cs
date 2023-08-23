using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private Collider ball;
    public Material onMaterial;
    public Material offMaterial;
    private new Renderer renderer;
    private SwitchState state;
    public ScoreManager scoreManager;
    private AudioSource audioSource;
    public VFXManager vFXManager;

    [SerializeField]
    [Tooltip("Point to be added to final score when passed")]
    private float point = 10;

    private enum SwitchState
    {
        ON,
        OFF,
        BLINK
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Bola").GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == ball) 
        {
            Toggle();
        }
    }

    void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.ON;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.OFF;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.BLINK;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.OFF;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private void Toggle()
    {
        if (state == SwitchState.ON)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        
        // scoreManager.AddScore(point);
        audioSource.Play();
        vFXManager.PlaySwitchVFX(transform.position);
    }
}
