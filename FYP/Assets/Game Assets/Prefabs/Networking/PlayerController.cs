using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float m_fSpeed = 4.0f; // Speed of the player
    public Rigidbody2D rbody; // Rigidbody2D component.
    public Vector2 m_moveVel; // Movement velocity.
    public string m_sLeftHorizontalAxis = "LeftJoystickHorizontal"; // Holds a string that is the left joystick horizontal axis.
    public string m_sLeftVerticalAxis = "LeftJoystickVertical"; // Holds a string that is the left joystick vertical axis.
    public string m_sResetButton = "reset"; // Resets the level.
    public Transform firePoint; // Where the bullet spawns.
    public int m_iHealth = 3; // Amount of hits the player can take. One hit = 1 health lost.

    public Shake shake; // Shake class object. (Shake.cs).
   // public GameObject camContainer; // Gameobject which contains the camera.
    public float shakeStrength = 0.1f; // Strength of the shake.
    public bool m_bDead = false; // Is the player dead.

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Get the component.
    }

    void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + m_moveVel * Time.fixedDeltaTime); // Move the player.
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(); // Run the function.
    }

    public void movePlayer()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(m_sLeftHorizontalAxis), Input.GetAxisRaw(m_sLeftVerticalAxis)); // Get the axises the player is using.
        m_moveVel = moveInput.normalized * m_fSpeed; // Move velocity.
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            m_bDead = false;
        }
        else
        {
            m_iHealth--;
            if(m_iHealth <= 0)
            {
                m_bDead = true; // Set it to true it will play the death animation.
                m_fSpeed = 0; // Set speed to 0.
                Destroy(gameObject); // Destroy the enemy after the animations played.
            }
            m_bDead = false; // Set it to true it will play the death animation. 
        }
    }
}
