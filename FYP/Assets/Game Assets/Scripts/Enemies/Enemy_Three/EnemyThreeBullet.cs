using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeBullet : Bullet
{
    Vector3 m_pos; // Position of the bullet.
    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 

    protected override void Start()
    {
        m_pos = transform.position;
        Invoke("DestroyProjectile", m_fLifetime); // Invoke the destroying projectile function from the base class.
    }

    
    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed;
        transform.position = m_pos;
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerTwo")
        {
            Destroy(gameObject);
        }
    }
}
