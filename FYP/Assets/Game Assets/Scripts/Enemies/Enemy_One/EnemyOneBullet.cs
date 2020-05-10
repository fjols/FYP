using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is for an enemy bullet in the game.
    It holds values like frequency.
 */

public class EnemyOneBullet : Bullet
{
    public float m_fWaveFrequency; // Frequency of the sine wave (How fast it moves).
    public float m_fMagnitude; // Magnitude. 
    public float m_fMovingMagnitude; // Magnitude. 
    Vector3 pos; // Position.


    // Start is called before the first frame update


    protected override void Start()
    {
        pos = transform.position; // The pos vector is set to the position of the bullet.
        Invoke("DestroyProjectile", m_fLifetime); // Destroy the bullet after a set amount of time.
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Make the bullet move down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMovingMagnitude; // Move it in a sine wave.
        transform.localScale = new Vector3(4f, 4f, 4f) * Mathf.Sin(m_fWaveFrequency * Time.time) * m_fMagnitude; // Scale the bullet in a sine wave.
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerTwo")
        {
            Destroy(gameObject); // Destroy the gameobject.
        }
    }
}
