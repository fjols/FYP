using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is for the first enemy type.
    It will control it and animate it.
 */
public class EnemyOneController : MonoBehaviour
{
    Animator m_anim; // The animator component.
    private bool m_bDead; // If this is true the explosion animation in the animator will be played.
    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the animator component.
        m_bDead = false; // Set it to false
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        m_bDead = true; // Set it to true it will play the death animation.
        m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
        Destroy(gameObject, 2.5f); // Destroy the enemy after the animations played.
    }
}
