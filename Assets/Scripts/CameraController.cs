using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 defaultPosition;

    public float returnTime;
    public float followSpeed;
    public float cameraToTargetDistance;
    public bool hasTarget {get {return target != null; }}

    private void Start() 
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update() 
    {
        if (hasTarget)
        {
            Vector3 targetPositon = target.position + (transform.rotation * -Vector3.forward  * cameraToTargetDistance);
            transform.position = Vector3.Lerp(transform.position, targetPositon, followSpeed * Time.deltaTime);
        }
    }

    public void FollowOnTarget(Transform targetTransform, float length)
    {
        target = targetTransform;
        cameraToTargetDistance = length;
    }

    public void ResetToDefault()
    {
        target = null;
        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, 1f));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0f, 1f, timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
