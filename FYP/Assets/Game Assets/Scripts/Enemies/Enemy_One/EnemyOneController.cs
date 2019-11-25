﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    This class is for the first enemy type.
    It will control it and animate it.
 */
public class EnemyOneController : MonoBehaviour
{
    Animator m_anim; // The animator component.
    public SpawnEnemy m_enemyHandler;
    public static int m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    public float m_fSpeed; // Speed of the enemy.
    private bool m_bDead; // If this is true the explosion animation in the animator will be played.
    private Rigidbody2D rb; // Rigidbody component.
    Vector3 pos; // Position.
    public float m_fWaveFrequency = 2.5f; // How fast the sine wave moves.
    public float m_fMagnitude = 0.5f; // The magnitude.

    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the animator component.
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component.
        m_enemyHandler = GetComponent<SpawnEnemy>();
        pos = transform.position; // The pos vector is set to the position of the enemy.
        m_bDead = false; // Set it to false.
        m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    }

    
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Make the enemy move down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMagnitude; // Move it in a sine wave.
        OffscreenDestroy(); // Check if enemy is offscreen.

        if(m_enemiesLeft <= 0) // If there are no enemies left.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
            SpawnEnemy.m_iCurrentEnemyCount = 0; // Spawn more enemies.
        }
    }

    void OffscreenDestroy()
    {
        // If the enemy goes off the screen then destroy it.
        if(transform.position.y < -7)
        {
            m_enemiesLeft--;
            Destroy(gameObject); // Don't need to play the animation here as you can't see it.
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBulletOne"){ m_bDead = false; } // Enemy shouldn't die if hit by a projectile from another enemy.
        else if(col.gameObject.tag == "EnemyOne"){ m_bDead = false; } // Enemy also shouldn't die if it is hit by another enemy.
        else
        {
            m_bDead = true; // Set it to true it will play the death animation.
            Manager.m_iScore++; // Add to the score.
            m_enemiesLeft--; // Decrement the enemies left in the game counter.
            m_fSpeed = 0; // Set speed to 0.
            m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
            m_fMagnitude = 0; // Set the magnitude to 0.
            m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
            Destroy(col.gameObject); // Destroy the bullet.
            Destroy(gameObject, 1f); // Destroy the enemy after the animations played.   
        }
    }
}
