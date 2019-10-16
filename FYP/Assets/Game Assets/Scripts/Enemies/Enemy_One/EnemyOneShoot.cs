using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class makes the enemy prefab shoot 2 bullets every few seconds.
 */

public class EnemyOneShoot : MonoBehaviour
{
    // Attributes
    public GameObject m_bullet; // Gameobject that will take the bullet prefab.
    public Transform[] firePoint; // The spot where the bullets will be instantiated.
    
    public float m_fShootingWait; // How long to wait before shooting again.

    private bool m_bCoroutineRunning = false; // Makes the coroutine run once rather than constantly.
    void Update()
    {
        StartCoroutine(Attack(m_fShootingWait)); // Run the coroutine.
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
        Instantiate(m_bullet,firePoint[0].position, firePoint[0].rotation);
        Instantiate(m_bullet,firePoint[1].position, firePoint[1].rotation);

        m_bCoroutineRunning = false; // Set the coroutine running variable to false.
    }

}
