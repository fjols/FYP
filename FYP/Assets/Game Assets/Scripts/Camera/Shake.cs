using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float m_fStrength; // The strength of the shake.
    public float m_fShakeDuration;
    public float m_fDampingSpeed;
    private Vector3 initialPos;
    private Transform m_fTransform;

    void Awake()
    {
        if(m_fTransform == null)
            m_fTransform = GetComponent(typeof(Transform)) as Transform;
    }
    
    void OnEnable()
    {
        initialPos = m_fTransform.localPosition;
    }

    void Update()
    {
        CameraShake();
    }

    void CameraShake()
    {
        if(m_fShakeDuration > 0)
        {
            m_fTransform.localPosition = initialPos + Random.insideUnitSphere * m_fStrength;
            m_fShakeDuration -= Time.deltaTime * m_fDampingSpeed;
        }
        else
        {
            m_fShakeDuration = 0;
            m_fTransform.localPosition = initialPos;
        }
    }

    public void TriggerShake(float duration)
    {
        m_fShakeDuration = duration;
    }
}
