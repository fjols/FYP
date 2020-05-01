using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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
    public int m_iHealth = 3; // Amount of hits the player can take. One hit = 1 health lost.
    public Animator m_anim; // The animator component.
    public bool m_bDead = false; // Is the player dead.

    public Text healthText; // Player health text.

    public Powerup _healthPowerUp;

    private Vector3 bestGuessPosition;

    [SyncVar] private Vector3 syncPos;
    private float m_fLerpFactor = 15.0f;

    void Awake()
    {
       // shake = camContainer.GetComponent<Shake>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Get the component.
        m_anim = GetComponent<Animator>(); // Get the animator component.
        healthText.text = "Health: " + m_iHealth;
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
            LerpPosition();
        }
    }

    [Command]
    void CmdUpdateMovement(Vector3 pos)
    {
        syncPos = pos;
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


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerUnit")
        {
            m_bDead = false;
        }
        else if(col.gameObject.tag == "Powerup")
        {
            m_bDead = false;
            m_iHealth = _healthPowerUp.healthIncrease;
            healthText.text = "Health: " + m_iHealth.ToString();
        }
        else
        {
            m_iHealth--;
            healthText.text = "Health: " + m_iHealth;
            if(m_iHealth <= 0)
            {
                m_bDead = true; // Set it to true it will play the death animation.
                m_fSpeed = 0; // Set speed to 0.
                m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
                Destroy(gameObject, 1f); // Destroy the enemy after the animations played.
                //shake.CameraShake(shakeStrength, 0.5f); // Shake the camera.   
            }
            m_bDead = false; // Set it to true it will play the death animation.
            //shake.CameraShake(shakeStrength, 0.5f); // Shake the camera.   
        }
    }
}
