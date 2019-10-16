using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class will make be a template for a bullet in the game.
    It will hold values such as its speed.
 */
[System.Serializable]
public class Bullet : MonoBehaviour
{
    // Attributes
    [SerializeField]
    protected float m_fSpeed; // The speed the bullet will be travelling at.
    
    [SerializeField]
    protected float m_fLifetime; // The lifetime of the bullet.
    
    protected virtual void Start()
    {
        Invoke("DestroyProjectile", m_fLifetime); // Destroy the bullet after a certain amount of time.
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject); // Destroy the gameobject.
    }
}
