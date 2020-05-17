using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerOneController : NetworkBehaviour
{
    [Tooltip("Speed of the player")]
    public float m_fSpeed = 4.0f; // Speed of the player
    [Tooltip("Rigidbody2D component.")]
    public Rigidbody2D rbody; // Rigidbody2D component.
    [Tooltip("Movement velocity")]
    public Vector3 m_moveVel; // Movement velocity.
    [Tooltip("This should be the joystick used for moving horizontally.")]
    public string m_sLeftHorizontalAxis = "LeftJoystickHorizontal"; // Holds a string that is the left joystick horizontal axis.
    [Tooltip("This should be the joystick used for moving vertically.")]
    public string m_sLeftVerticalAxis = "LeftJoystickVertical"; // Holds a string that is the left joystick vertical axis.
    [Tooltip("This button should reset the game.")]
    public string m_sResetButton = "reset"; // Resets the level.
    [Tooltip("The point from which the bullets fire.")]
    public Transform firePoint; // Where the bullet spawns.
    [Tooltip("How much health a player has.")]
    public int m_iHealth = 30; // Amount of hits the player can take. One hit = 1 health lost.
    //public Animator m_anim; // The animator component.
    public bool m_bDead = false; // Is the player dead.
    [SyncVar] private Vector3 syncPos; // The position to be synced using command function.
    [SyncVar] private int syncHealth; // The health to be synced using command function.
    private float m_fLerpFactor = 15.0f; // The factor of which to lerp at.

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Get the component.
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        if(isLocalPlayer)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw(m_sLeftHorizontalAxis), Input.GetAxisRaw(m_sLeftVerticalAxis)); // Get the axises the player is using.
            m_moveVel = moveInput.normalized * m_fSpeed; // Move velocity.
            transform.position += m_moveVel * Time.deltaTime; // Move the player.
            TransmitPosition();
            TransmitHealth();
            LerpPosition();
        }
    }

    [Command]
    void CmdUpdateMovement(Vector3 pos)
    {
        syncPos = pos;
    }

    [Command]
    void CmdUpdateHealth(int health)
    {
        syncHealth = health;
    }

    void LerpPosition()
    {
        if(!isLocalPlayer)
            transform.position = Vector3.Lerp(transform.position, syncPos, Time.deltaTime * m_fLerpFactor);
    }

    [ClientCallback]
    void TransmitPosition()
    {
        CmdUpdateMovement(transform.position);
    }

    [ClientCallback]
    void TransmitHealth()
    {
        CmdUpdateHealth(m_iHealth);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerUnit")
        {
            m_bDead = false;
        }
        else if(col.gameObject.CompareTag("EnemyOneBullet") || col.gameObject.CompareTag("EnemyTwoBullet") ||
                col.gameObject.CompareTag("EnemyThreeBullet") || col.gameObject.CompareTag("BossBullet"))
        {
            m_iHealth--;
            //healthText.text = "Health: " + m_iHealth;
            if(m_iHealth <= 0)
            {
                m_bDead = true; // Set it to true it will play the death animation.
                m_fSpeed = 0; // Set speed to 0.
                Destroy(gameObject); // Destroy the enemy after the animations played.
                Debug.Log("Health: " + m_iHealth);
                SceneManager.LoadScene("death");
            }
            m_bDead = false; // Set it to true it will play the death animation.
        }
    }
}
