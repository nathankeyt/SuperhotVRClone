using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject rightHandController;
    [SerializeField] private GameObject leftHandController;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private float velocity_upper_threshold = 1f;
    [SerializeField] private float velocity_lower_threshold = 1f;

    private Vector3 rightLastPos;
    private Vector3 leftLastPos;
    private Vector3 cameraLastPos;
        
    // Start is called before the first frame update
    void Start()
    {
        SetLastPos();
    }

    // Update is called once per frame
    void Update()
    {
        var maxDeltaPos = (rightHandController.transform.position - rightLastPos).magnitude;
        maxDeltaPos = Math.Max(maxDeltaPos, (leftHandController.transform.position - leftLastPos).magnitude);
        maxDeltaPos = Math.Max(maxDeltaPos, (playerCamera.transform.position - cameraLastPos).magnitude);

        //print((playerCamera.transform.position - cameraLastPos).magnitude);
        var speed = maxDeltaPos / Time.deltaTime;
        //Debug.Log(velocity);
        
        if (!speed.IsUndefined())
            Time.timeScale = Math.Min(velocity_upper_threshold, speed);
        
        SetLastPos();
    }

    private void SetLastPos()
    {
        rightLastPos = rightHandController.transform.position;
        leftLastPos = leftHandController.transform.position;
        cameraLastPos = playerCamera.transform.position;
    }
}
