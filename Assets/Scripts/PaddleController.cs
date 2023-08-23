using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    private KeyCode input;
    private new HingeJoint hingeJoint;
    [SerializeField]
    private float springPower = 1000;
    [SerializeField]
    private bool reversed = true;
    
    private float targetPressed;
    private float targetRelease;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();

        targetPressed = reversed ? hingeJoint.limits.max : hingeJoint.limits.min;
        targetRelease = reversed ? hingeJoint.limits.min : hingeJoint.limits.max;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hingeJoint.spring;

        if (Input.GetKey(input)) 
        {
            jointSpring.targetPosition = targetPressed;
        }
        else 
        {
            jointSpring.targetPosition = targetRelease;
        }

        hingeJoint.spring = jointSpring;
    }
}
