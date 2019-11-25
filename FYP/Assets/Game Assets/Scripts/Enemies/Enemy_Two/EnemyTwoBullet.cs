using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBullet : Bullet
{
    Vector3 m_pos;

    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 
    private float m_fAngle = 0f;
    public float m_offset = 45f;
    protected override void Start()
    {
        m_pos = transform.position;
        Invoke("DestroyProjectile", m_fLifetime);
    }

    
    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed;
        transform.position = m_pos;
        transform.localScale = new Vector3(4f, 4f, 4f) * Mathf.Sin(m_fWaveFrequency * Time.time) * m_fMagnitude;
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerTwo")
        {
            Destroy(gameObject); // Destroy the gameobject.
        }
    }
}
