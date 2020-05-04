using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS THE SHOOTING CLASS FOR THE PLAYER ON THE SAME PC GAME.
public class PlayerShoot : MonoBehaviour
{
    [Tooltip("The button to activate the shooting.")]
    public string m_sAButton; // The a button.
    [Tooltip("The shooting sound.")]
    public AudioSource shootSound; // Shooting Sound.
    [Tooltip("The bullet gameobject to be instantiated.")]
    public GameObject m_bullet; // The bullet gameobject.
    [Tooltip("Where to fire the bullet from.")]
    public Transform firePoint; // Where the bullet spawns.

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(m_sAButton))
        {
            Shoot(); // Shoot the bullet.
        }
    }

    void Shoot()
    {
        Instantiate(m_bullet, firePoint.position, firePoint.rotation); // Instantiate the bullet.
        shootSound.Play(); // Play a sound when the bullet fires.
    }
}
