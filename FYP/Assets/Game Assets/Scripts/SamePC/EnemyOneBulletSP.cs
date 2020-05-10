using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneBulletSP : SamePCBullet
{
    [Tooltip("Frequency of the wave.")]
    public float m_fWaveFrequency;
    [Tooltip("The magnitude of the wave. This is the magnitude for movement.")]
    public float m_fMagnitude;
    [Tooltip("The magnitude of the wave. This is the magnitude for scale.")]
    public float m_fScaleMagnitude;
    Vector3 pos;

    
    protected override void Start()
    {
        pos = transform.position; // Set the position.
        Invoke("DestroyProjectile", m_fLifetime); // Destroy the bullet after a set amount of time.
    }

    
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Move the bullet down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMagnitude; // Move it in a sine wave.
        transform.localScale = new Vector3(4f, 4f, 4f) * Mathf.Sin(m_fWaveFrequency * Time.time) * m_fScaleMagnitude; // Scale the bullet using a sine wave for smooth scaling.
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("PlayerTwo"))
        {
            Destroy(gameObject); // Destroy the gameobject.
        }
    }
}