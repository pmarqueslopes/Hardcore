using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }
}
