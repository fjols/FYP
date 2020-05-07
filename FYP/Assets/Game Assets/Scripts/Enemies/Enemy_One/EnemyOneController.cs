using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
    This class is for the first enemy type.
    It will control it and animate it.
 */
public class EnemyOneController : NetworkBehaviour
{
    Animator m_anim; // The animator component.
    public SpawnEnemy m_enemyHandler;
    public static int m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    public float m_fSpeed; // Speed of the enemy.
    private bool m_bDead; // If this is true the explosion animation in the animator will be played.
    private Rigidbody2D rb; // Rigidbody2D component.
    Vector3 pos; // Position.
    public float m_fWaveFrequency = 2.5f; // How fast the sine wave moves.
    public float m_fMagnitude = 0.5f; // The magnitude.

    private float m_fLerpRate; // Rate to lerp.
    [SyncVar] private Vector3 syncPosition;

    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the animator component.
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody2D component.
        m_enemyHandler = GetComponent<SpawnEnemy>();
        pos = transform.position; // The pos vector is set to the position of the enemy.
        m_bDead = false; // Set it to false.
        m_enemiesLeft = SpawnEnemy.m_iCurrentEnemyCount;
    }

    
    void Update()
    {
        pos += transform.up * Time.deltaTime * -m_fSpeed; // Make the enemy move down the screen.
        transform.position = pos + transform.right * Mathf.Sin(Time.time * m_fWaveFrequency) * m_fMagnitude; // Move it in a sine wave.
        
        TransmitEnemyPos(); // Transmit the enemy position to the server.
        LerpPosition(); // Lerp the position for smooth movement for clients.
        OffscreenDestroy(); // Check if enemy is offscreen.
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
        syncPosition = pos;
    }

    [ClientCallback]
    void TransmitEnemyPos()
    {
        CmdUpdateMovement(transform.position);
    }

    void LerpPosition()
    {
        if(!isLocalPlayer)
            transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * m_fLerpRate);
    }

    [ClientRpc]
    void RpcDestroyEnemy()
    {
        m_bDead = true;
        m_fSpeed = 0; // Set speed to 0.
        m_fWaveFrequency = 0; // Set the frequency of the wave to 0.
        m_fMagnitude = 0; // Set the magnitude to 0.
        StartCoroutine(DestroySequence());
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
        else if (col.gameObject.CompareTag("PlayerUnit")) {m_bDead = false; SceneManager.LoadScene("death");}
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
            RpcDestroyEnemy();
            Destroy(col.gameObject); // Destroy the bullet.
            m_enemiesLeft--; // Decrement the enemies left in the game counter.
        }
    }

    IEnumerator DestroySequence()
    {
        m_anim.SetBool("Death", m_bDead);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
