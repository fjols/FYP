using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour
{
    public float m_fFrequency;
    public float m_fMagnitude;
    public float m_fOffset;
    Vector3 pos;
    void Update()
    {
        float y = Mathf.Sin(Time.time * m_fFrequency) * m_fMagnitude + m_fOffset;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
