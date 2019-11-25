using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class lets the player shoot with the controller.
 */
public class Shooting : MonoBehaviour
{
    public string m_sAButton; // The a button.
    public AudioSource shootSound; // Shooting Sound.
    public GameObject m_bullet; // The bullet gameobject.
    public Transform firePoint; // Where the bullet spawns.
    void Update()
    {
        if(Input.GetButtonDown(m_sAButton))
        {
            Shoot(); // Call the shoot method.
            shootSound.Play();
        }
    }

    void Shoot()
    {
        Instantiate(m_bullet, firePoint.position, firePoint.rotation); // Make a bullet spawn.
    }
}
