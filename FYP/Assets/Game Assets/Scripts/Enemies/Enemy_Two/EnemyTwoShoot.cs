using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoShoot : MonoBehaviour
{
    public GameObject m_bullet; // Bullet to use.
    public Transform[] m_firePoint; // Where to fire the bullet from.
    public float m_fShootingCoolDown; // How long between each bullet being fired.
    private bool m_bCoroutineRunning = false; // Is the coroutine running.

    void Update()
    {
        StartCoroutine(Attack(m_fShootingCoolDown)); // Run the coroutine.
    }
    
    IEnumerator Attack(float time)
    {
        if(m_bCoroutineRunning) // If the coroutine runs.
        {
            yield break; // Break out of it.
        }
        m_bCoroutineRunning = true; // Set the coroutine running variable to true.
        yield return new WaitForSeconds(time); // Wait for the specified amount of time.

        // This enemy will attack by shooting 2 bullets. Below instantiates them into the scene.
        Instantiate(m_bullet,m_firePoint[Random.Range(0, 3)].position, m_firePoint[0].rotation);

        m_bCoroutineRunning = false; // Set the coroutine running variable to false.
    }
}
