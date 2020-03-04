using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeShoot : MonoBehaviour
{
    public GameObject m_bullet; // Bullet to use.
    public Transform m_firePoint; // Where to fire the bullet from.
    public float m_fShootingCoolDown; // How long between each bullet being fired.
    private bool m_bCoroutineRunning = false; // Is the coroutine running.

    void Update()
    {
        StartCoroutine(Attack(m_fShootingCoolDown)); // Run the coroutine.
    }

    IEnumerator Attack(float time) /*param time - how long between each bullet being fired.*/
    {
        if(m_bCoroutineRunning) // If the couroutine is running
        {
            yield break; 
        }
        m_bCoroutineRunning = true;
        yield return new WaitForSeconds(time); // Wait for set time.
        Instantiate(m_bullet, m_firePoint.position, m_firePoint.rotation); // Instantiate a new bullet.
        m_bCoroutineRunning = false; // Coroutine is no longer running.
    }

}
