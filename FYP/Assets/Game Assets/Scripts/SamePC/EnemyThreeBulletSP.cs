using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeBulletSP : SamePCBullet
{
    Vector3 m_pos;
    [Tooltip("Frequency of the wave.")] public float m_fWaveFrequency;
    [Tooltip("Magnitude of the wave.")] public float m_fMagnitude;
    [Tooltip("Speed of which the bullet will travel.")][SerializeField] float m_fSpeed;
    [Tooltip("Lifetime of the bullet. It is destroyed after this amount of time.")][SerializeField] float m_fLifetime;

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
        if(col.gameObject.CompareTag("PlayerUnit"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
