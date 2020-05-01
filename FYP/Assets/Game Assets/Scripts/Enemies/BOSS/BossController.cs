using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BossController : NetworkBehaviour
{
    Animator m_anim; // The bosses animator component.
    [Tooltip("This is the object which spawns the enemys.")]
    public SpawnEnemy m_enemyHandler; // Where the boss will be spawned from.
    [Tooltip("The speed of which the boss will move.")]
    public float m_fSpeed; // How fast the boss will move.
    [Tooltip("Is the boss alive?")]
    public static bool m_bDead; // Is the boss dead.
    private Rigidbody2D rb; // Rigidbody2D component.
    private Vector3 pos; // Position of the enemy.
    [Tooltip("The frequency of the wave. This affects how fast the wave will move.")]
    public float m_fWaveFrequency = 0.2f; // Frequency of the wave.
    [Tooltip("The magnitude of the wave.")]
    public float m_fMagnitude = 0.5f; // Magnitude of the wave.
    [Tooltip("How much health the enemy has.")]
    public int m_iHealth = 10; // How much health the enemy has.

    [Tooltip("When this time hits 0 then the boss will change direction.")]
    public float m_fTime; // When time hits certain point change direction.
    private float m_fOriginalTime; // Reset the countdown time to this after it hits 0

    private Vector3 positionOne = new Vector3(-7, 3.25f, 0);
    private Vector3 positionTwo = new Vector3(7, 3.25f, 0);

    private float lerpRate = 15.0f;
    [SyncVar] private Vector3 syncPosition;
    [SyncVar] private Quaternion bossRotation;

    void Start()
    {
        m_anim = GetComponent<Animator>(); // Get the bosses animator component.
        rb = GetComponent<Rigidbody2D>(); // Get the bosses rigidbody2D component.
        m_enemyHandler = GetComponent<SpawnEnemy>(); // Get the spawn enemy component.
        pos = transform.position; // The position vector is the position of the boss.
        m_bDead = false; // Boss is not dead.
    }

    void Update()
    {
        transform.position = Vector3.Lerp(positionOne, positionTwo, (Mathf.Sin(m_fSpeed * Time.time) + 1.0f) / 2.0f);
        if(!m_bDead)
        {
            transform.Rotate(0.0f, 0.0f, 5.0f, Space.Self);
        }
        TransmitBossPos();
        TransmitRotation();
        LerpBossPosition();
        LerpBossRotation();
        OffscreenDestroy();
    }

    void OffscreenDestroy()
    {
        if(transform.position.y < -7 || transform.position.x < -7 || transform.position.x > 7)
        {
            Destroy(gameObject); // Destroy the boss.
        }
    }

    void LerpBossPosition() // Smooth movement for clients.
    {
        if(!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * lerpRate);
        }
    }

    void LerpBossRotation() // Smooth rotation for clients.
    {
        if(!isLocalPlayer)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, bossRotation, Time.deltaTime * lerpRate);
        }
    }

    [Command]
    void CmdUpdateMovement(Vector3 pos)
    {
        syncPosition = pos;
    }

    [ClientCallback]
    void TransmitBossPos()
    {
        CmdUpdateMovement(transform.position);
    }

    [Command]
    void CmdGiveRotationsToServer(Quaternion rot)
    {
        bossRotation = rot;
    }

    [Client]
    void TransmitRotation()
    {
        if(isLocalPlayer)
        {
            CmdGiveRotationsToServer(transform.rotation);
        }
    }


    [Command]
    void CmdDestroyBoss()
    {
        m_bDead = true;
        m_fSpeed = 0;
        StartCoroutine(DestroySequence());
    }

    [ClientRpc]
    void RpcDestroyBoss() // Will run the boss destruction sequence on a clients game instance.
    {
        m_bDead = true;
        m_fSpeed = 0;
        StartCoroutine(DestroySequence());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("PlayerUnit")) { m_bDead= false; Debug.Log("HIT: " + col.gameObject.tag); }
        else if(col.gameObject.CompareTag("PlayerBullet"))
        {
            m_bDead = false;
            m_iHealth--; // Take health off when hit by a bullet.
            Debug.Log("HIT BY PLAYER BULLET");
        }
        else if(m_bDead == false && m_iHealth <= 0)
        {
           
            Debug.Log("BOSS DEAD");
            m_bDead = true;
            m_fSpeed = 0;
            StartCoroutine(DestroySequence());
            RpcDestroyBoss();
        }
    }

    IEnumerator DestroySequence()
    {
        m_anim.SetBool("Death", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
