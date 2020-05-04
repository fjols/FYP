using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    Manager _gm;
    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 
    [SerializeField]
    float m_fSpeed; // The speed the bullet will be travelling at.
    
    [SerializeField]
    float m_fLifetime; // The lifetime of the bullet.

    void Start()
    {
        _gm = GetComponent<Manager>();
        Invoke("DestroyProjectile", m_fLifetime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(transform.up * m_fSpeed * Time.deltaTime);
        transform.localScale = new Vector3(4f, 4f, 4f) * Mathf.Sin(m_fWaveFrequency * Time.time) * m_fMagnitude;
    }
}
