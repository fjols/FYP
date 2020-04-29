using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyThreeBullet : MonoBehaviour
{
    Vector3 m_pos; // Position of the bullet.
    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 
    [SerializeField]
    float m_fSpeed; // The speed the bullet will be travelling at.
    
    [SerializeField]
    float m_fLifetime; // The lifetime of the bullet.
    void Start()
    {
        m_pos = transform.position;
        Invoke("DestroyProjectile", m_fLifetime); // Invoke the destroying projectile function from the base class.
    }

    void DestroyProjectile()
    {
        Destroy(gameObject); // Destroy the gameobject.
    }

    
    void Update()
    {
            m_pos += transform.up * Time.deltaTime * -m_fSpeed; // Update the position.
            transform.position = m_pos; // Update the positon.
        
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerUnit")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
