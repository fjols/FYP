using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePCBullet : MonoBehaviour
{
    [Tooltip("The speed the bullet moves.")]
    [SerializeField] protected float m_fSpeed;
    [Tooltip("How long the bullet will be in existance for before being deleted.")]
    [SerializeField] protected float m_fLifetime;

    protected virtual void Start()
    {
        Invoke("DestroyProjectile", m_fLifetime); // Call this function after set amount of time.
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject); // Destroy the gameobject when this function is called.
    }
}
