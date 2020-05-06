using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneManager : MonoBehaviour
{
    Animator m_anim; // The animator component.
    [Tooltip("This component spawns the enemies.")]
    public SpawnEnemy m_enemyHandler;
    [Tooltip("Speed of the enemy.")]
    public float m_fSpeed; // Speed of the enemy.
    [Tooltip("Is the enemy dead?")]
    private bool m_bDead; // If this is true the explosion animation in the animator will be played.
    [Tooltip("Rigidbody2D component.")]
    private Rigidbody2D rb; // Rigidbody2D component.
    [Tooltip("Position of the enemy.")]
    Vector3 pos; // Position.
    [Tooltip("Wave Frequency in the wave used for movement.")]
    public float m_fWaveFrequency = 2.5f; // How fast the sine wave moves.
    [Tooltip("Magnitude used in the wave used for movement.")]
    public float m_fMagnitude = 0.5f; // The magnitude.

    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the animator component.
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody2D component.
        m_enemyHandler = GetComponent<SpawnEnemy>();
        pos = transform.position; // The pos vector is set to the position of the enemy.
        m_bDead = false; // Set it to false.
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Make the enemy move down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMagnitude; // Move it in a sine wave.
        OffscreenDestroy();
    }

    void OffscreenDestroy()
    {
        // If the enemy goes off the screen then destroy it.
        if(transform.position.y < -7)
        {
            Destroy(gameObject); // Don't need to play the animation here as you can't see it.
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("EnemyBulletOne")){ m_bDead = false; } // Enemy shouldn't die if hit by a projectile from another enemy.
        else if(col.gameObject.CompareTag("EnemyOne") ||
        col.gameObject.CompareTag("EnemyTwo") ||
        col.gameObject.CompareTag("EnemyTwoBullet")){ m_bDead = false; } // Enemy also shouldn't die if it is hit by another enemy.
        else if(col.gameObject.CompareTag("EnemyThree")){ m_bDead = false; }
        else if(col.gameObject.CompareTag("EnemyThreeBullet")){ m_bDead = false; }
        else if(col.gameObject.CompareTag("Boss") || col.gameObject.CompareTag("BossBullet")){ m_bDead = false; }
        else if(m_bDead == false)
        {
            m_bDead = true; // Set it to true it will play the death animation.
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 2.0f);
            transform.position = newPos; // Move the enemy back after its been shot so it wont be affect by more bullets.
            Manager.m_iScore++; // Add to the score.
            m_fSpeed = 0; // Set speed to 0.
            m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
            m_fMagnitude = 0; // Set the magnitude to 0.
            StartCoroutine(DestroySequence());
            Destroy(col.gameObject); // Destroy the bullet.
        }
    }
    IEnumerator DestroySequence()
    {
        m_anim.SetBool("Death", m_bDead);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
