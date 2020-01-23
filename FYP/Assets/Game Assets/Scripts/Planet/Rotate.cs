using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float m_fRotationSpeed; // Speed of which the planet will rotate.

    void Update()
    {
        transform.Rotate(0, m_fRotationSpeed, 0); // Rotate the planet around the Y axis.
    }
}
