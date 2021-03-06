﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeManager : MonoBehaviour
{
    [Tooltip("This component spawns the enemy.")]
    public SpawnEnemy m_enemyHandler; // Component which handles enemies.
    [Tooltip("Speed of the enemy.")]
    public float m_fSpeed; // Speed of the enemy.
    private bool m_bDead; // Is the enemy dead.
    private Rigidbody2D rb; // Rigidbody2D component.
    Vector3 m_pos; // Position of the enemy.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_enemyHandler = GetComponent<SpawnEnemy>();
        m_pos = transform.position;
        m_bDead = false;
    }

    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed; // Move the enemy down the screen.
        transform.position = m_pos + transform.right * Mathf.Cos(Time.time * 0.1f) * 2f * Mathf.Sin(Time.time * 4) * 2 * Mathf.Cos(Time.time); // Move it in a cool wave
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
        else if(col.gameObject.CompareTag("EnemyOne")){ m_bDead = false; } // Enemy also shouldn't die if it is hit by another enemy.
        else if(col.gameObject.CompareTag("EnemyTwoBullet") ||
                col.gameObject.CompareTag("EnemyTwo")) { m_bDead = false; } // Do not destroy if its related to enemy.
        else if(col.gameObject.CompareTag("Boss") || col.gameObject.CompareTag("BossBullet")){ m_bDead = false; }
        else if(col.gameObject.CompareTag("EnemyThree") || col.gameObject.CompareTag("EnemyThreeBullet")){ m_bDead = false; }
        else if(m_bDead == false)
        {
            m_bDead = true; // Set it to true it will play the death animation.
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 2.0f);
            transform.position = newPos; // Move the enemy back after its been shot so it wont be affect by more bullets.
            Manager.m_iScore++; // Add to the score.
            m_fSpeed = 0; // Set speed to 0.
            //m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
            //m_fMagnitude = 0; // Set the magnitude to 0.
           // m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
            Destroy(col.gameObject); // Destroy the bullet.
            StartCoroutine(DeathSequence());
        }
    }
    IEnumerator DeathSequence()
    {
        m_fSpeed = 0;
        yield return new WaitForSeconds(0);
        Destroy(gameObject);
    }
}
