using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
    public Collider ball;
    public CameraController cameraController;
    [SerializeField]
    private float cameraDistanceToTarget;
    void OnTriggerEnter(Collider other)
    {
        if(other == ball)
        {
            cameraController.FollowOnTarget(ball.transform, cameraDistanceToTarget);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other == ball)
        {
            cameraController.ResetToDefault();
        }
    }
}
