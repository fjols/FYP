using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class will make be a template for a bullet in the game.
    It will hold values such as its speed.
 */

public class Bullet : MonoBehaviour
{
    // Attributes
    [SerializeField]
    private float m_fSpeed; // The speed the bullet will be travelling at.
    
    [SerializeField]
    private float m_fLifetime; // The lifetime of the bullet.
    
    void Start()
    {
        Invoke("DestroyProjectile", m_fLifetime);
    }

    void Update()
    {
        transform.Translate(transform.up * m_fSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
