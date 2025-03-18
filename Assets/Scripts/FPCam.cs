using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCam : MonoBehaviour
{
    public float xAxis;
    public float yAxis;

    private float yAxisTurnRate = 720f;
    private float xAxisTurnRate = 720f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0);

        Camera.main.transform.rotation = newRotation;
    }

    public void AddXAxisInput(float input)
    {

        xAxis -= input * xAxisTurnRate;
        xAxis = Mathf.Clamp(xAxis, -90f, 90f);
    }

    public void AddYAxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
}
