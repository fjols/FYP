using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BossBullet : NetworkBehaviour
{
    Vector3 m_pos;
    [Tooltip("Frequency of the wave.")]
    public float m_fWaveFrequency;
    [Tooltip("Magnitude of the wave.")]
    public float m_fMagnitude;
    [Tooltip("Speed of the bullet.")]
    public float m_fSpeed;
    [Tooltip("How long the bullet will be in existance.")]
    public float m_fLifeTime;
    [SyncVar] private Vector3 syncPosition;
    private float m_fLerpRate = 2.5f;
    void Start()
    {
        m_pos = transform.position;
        Invoke("DestroyProjectile", m_fLifeTime); // Destroy the bullet after its lifetime is up.
    }

    void Update()
    {
        m_pos += transform.up * Time.deltaTime * -m_fSpeed;
        transform.position = m_pos;
        //TransmitPosition();
        //LerpPos();
        if(isLocalPlayer)
            CmdUpdatePosition(transform.position);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject); // Destroy the bullet.
    }

    [Command]
    void CmdUpdatePosition(Vector3 pos)
    {
      // syncPosition = pos;
       transform.position = pos;
    }


    [ClientCallback]
    void TransmitPosition()
    {
        CmdUpdatePosition(transform.position);
    }

    void LerpPos()
    {
        if(!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * m_fLerpRate);
        }
    }

    void OnCollision2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("PlayerUnit"))
        {
            Debug.Log("Hit: " + col.gameObject.tag);
            Destroy(gameObject); // Destroy the bullet if it hits a player.
        }
    }
}
