using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperChangeColor : MonoBehaviour
{
    // public Color color;
    
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Random.ColorHSV());
        // renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
