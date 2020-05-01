using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [Tooltip("The bullet to be fired")]
    public GameObject m_bullet; // Bullet gameobject.
    [Tooltip("Where the bullet will be fired from")]
    public Transform m_firePoint; // Where the bullet fires from.
    [Tooltip("How long between each bullet being fired")]
    public float m_fShootingCooldown; // How long between shooting.
    private bool m_bCoroutineRunning = false; // Is the couroutine running.

    void Update()
    {
        if(!BossController.m_bDead) // Only do these things whilst the boss is alive.
        {
            StartCoroutine(Attack(m_fShootingCooldown)); // Run the coroutine.
           // m_firePoint.Rotate(0.0f, 0.0f, 40.0f, Space.Self);
        }
    }

    IEnumerator Attack(float time)
    {
        if(m_bCoroutineRunning) // If the couroutine is running.
        {
            yield break; 
        }
        m_bCoroutineRunning = true; // Run the coroutine.
        yield return new WaitForSeconds(time); // Wait for a set amount of time.
        Instantiate(m_bullet, m_firePoint.position, m_firePoint.rotation); // Create a bullet.
        m_bCoroutineRunning = false; // Stop running the coroutine.
    }
}
