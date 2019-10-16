using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is for the first enemy type.
    It will control it and animate it.
 */
public class EnemyOneController : MonoBehaviour
{
    Animator m_anim; // The animator component.
    public float m_fSpeed; // Speed of the enemy.
    private bool m_bDead; // If this is true the explosion animation in the animator will be played.
    private Rigidbody2D rb; // Rigidbody component.
    Vector3 pos; // Position.

    public float m_fWaveFrequency; // How fast the sine wave moves.
    public float m_fMagnitude; // The magnitude.

    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the animator component.
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component.
        pos = transform.position; // The pos vector is set to the position of the enemy.
        m_bDead = false; // Set it to false
    }

    
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Make the enemy move down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMagnitude; // Move it in a sine wave.
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        m_bDead = true; // Set it to true it will play the death animation.
        m_fSpeed = 0; // Set speed to 0.
        m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
        m_fMagnitude = 0; // Set the magnitude to 0.
        m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
        Destroy(gameObject, 1f); // Destroy the enemy after the animations played.
    }
}
