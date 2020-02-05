using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class will be a player bullet in the game.
    It will hold values such as its wave magnitude and frequency.
 */

[System.Serializable]
public class PlayerBullet : Bullet
{

    Manager _gm;
    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 
    
    protected override void Start()
    {
        _gm = GetComponent<Manager>();
        Invoke("DestroyProjectile", m_fLifetime); // Invoke the virtual method DestroyProjectile from the Bullet base class.
    }

    void Update()
    {
        transform.Translate(transform.up * m_fSpeed * Time.deltaTime); // Move the bullet up the screen.
        transform.localScale = new Vector3(4f, 4f, 4f) * Mathf.Sin(m_fWaveFrequency * Time.time) * m_fMagnitude; // Scale the bullet in a sine wave.
    }

    public void SpeedIncrease(float _speedIncrease)
    {
        m_fSpeed = _speedIncrease;
    }
}
