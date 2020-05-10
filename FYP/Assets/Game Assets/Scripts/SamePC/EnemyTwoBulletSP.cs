using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBulletSP : SamePCBullet
{
    [Tooltip("Frequency of the wave.")]
    public float m_fWaveFrequency;
    [Tooltip("The magnitude of the wave. This is the magnitude for movement.")]
    public float m_fMagnitude;
    Vector3 m_pos;
    
    protected override void Start()
    {
        m_pos = transform.position;
        Invoke("DestroyProjectile", m_fLifetime);
    }

    
    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed;
        transform.position = m_pos;
    }
    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("PlayerTwo"))
        {
            Destroy(gameObject); // Destroy the gameobject.
        }
    }
}
