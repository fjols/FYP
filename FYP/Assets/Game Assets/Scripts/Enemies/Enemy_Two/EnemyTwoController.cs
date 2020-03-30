﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EnemyTwoController : NetworkBehaviour
{
    Animator m_anim;
    public SpawnEnemy m_enemyHandler;
    public static int m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    public float m_fSpeed;
    private bool m_bDead;
    private Rigidbody2D rb;
    Vector3 m_pos;
    
    void Start()
    {
        m_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        m_enemyHandler = GetComponent<SpawnEnemy>();
        m_pos = transform.position;
        m_bDead = false;
        m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    }

    
    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed; // Move the enemy.
        transform.position = m_pos;
        CmdUpdateMovement(transform.position); // Run the command function.
        OffscreenDestroy(); // Destroy the enemy when it gets offscreen.
        if(m_enemiesLeft <= 0) // If there are no enemies then reload the scene to make more enemies.
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

    [Command]
    void CmdUpdateMovement(Vector3 pos)
    {
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("EnemyBulletOne")){ m_bDead = false; } // Enemy shouldn't die if hit by a projectile from another enemy.
        else if(col.gameObject.CompareTag("EnemyOne")){ m_bDead = false; } // Enemy also shouldn't die if it is hit by another enemy.
        else if(col.gameObject.CompareTag("EnemyTwoBullet") ||
                col.gameObject.CompareTag("EnemyTwo")) { m_bDead = false; } // Do not destroy if its related to enemy.
        else if(m_bDead == false)
        {
            m_bDead = true; // Set it to true it will play the death animation.
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 2.0f);
            transform.position = newPos; // Move the enemy back after its been shot so it wont be affect by more bullets.
            Manager.m_iScore++; // Add to the score.
            m_fSpeed = 0; // Set speed to 0.
            //m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
            //m_fMagnitude = 0; // Set the magnitude to 0.
            m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
            Destroy(col.gameObject); // Destroy the bullet.
            Destroy(gameObject, 1f); // Destroy the enemy after the animations played.   
            m_enemiesLeft--; // Decrement the enemies left in the game counter.
        }
    }

}
