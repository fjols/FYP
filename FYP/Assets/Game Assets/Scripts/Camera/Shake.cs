using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Camera mainCamera; // Camera to use.
    float m_fShakeAmount = 0; // Amount of shaking to do.
 
    void Awake()
    {
        if(mainCamera == null) // Assign the camera.
            mainCamera = Camera.main;
    }

    public void CameraShake(float strength, float duration)
    {
        m_fShakeAmount = strength; // Set the strength of the shake.
        InvokeRepeating("BeginShake", 0, 0.01f); // Invoke the shake method repeatedly.
        Invoke("StopShake", duration); // Stop the shaking after a set time.
    }
    void BeginShake()
    {
        if(m_fShakeAmount > 0) // If the shake amount is greater than 0.
        {
            Vector3 camPos = mainCamera.transform.position; // Get the cameras position.
            float offsetX = Random.value * m_fShakeAmount * 2 - m_fShakeAmount; // Randomly offset on the X axis.
            float offsetY = Random.value * m_fShakeAmount * 2 - m_fShakeAmount; // Randomly offset on the Y axis.
            camPos.x += offsetX; // Add this offset to the cameras x axis.
            camPos.y += offsetY; // Add this offset to the cameras y axis.
            mainCamera.transform.position = camPos; // Set the position.
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake"); // Stop shaking.
        mainCamera.transform.localPosition = Vector3.zero; // Reset the camera position.
    }
}
