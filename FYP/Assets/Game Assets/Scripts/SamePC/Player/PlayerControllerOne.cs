using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// PLAYER CONTROLLER FOR SAME PC GAME.
public class PlayerControllerOne : MonoBehaviour
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
    //public Animator m_anim; // The animator component.
    public bool m_bDead = false; // Is the player dead.



    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(m_sLeftHorizontalAxis), Input.GetAxisRaw(m_sLeftVerticalAxis));
        m_moveVel = moveInput.normalized * m_fSpeed;
        transform.position += m_moveVel * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
            m_bDead = false;
        else
        {
            m_iHealth--;
            Debug.Log("Health" + m_iHealth);
            if(m_iHealth <= 0)
            {
                m_bDead = true;
                m_fSpeed = 0;
               // m_anim.SetBool("Death", m_bDead);
                Destroy(gameObject);
                SceneManager.LoadScene("death");
            }
            m_bDead = false;
        }
    }
}
