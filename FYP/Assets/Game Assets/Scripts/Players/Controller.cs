using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The player controller class.
 */
public class Controller : MonoBehaviour
{
    public float m_fSpeed; // Speed of the player
    private Rigidbody2D rbody; // Rigidbody2D component.
    private Vector2 m_moveVel; // Movement velocity.
    private float m_fheadingAngle; // Heading angle, used for rotation.
    public string m_sLeftHorizontalAxis; // Holds a string that is the left joystick horizontal axis.
    public string m_sLeftVerticalAxis; // Holds a string that is the left joystick vertical axis.
    public Transform firePoint; // Where the bullet spawns.

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Get the component.
    }

    void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + m_moveVel * Time.fixedDeltaTime); // Move the player.
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(m_sLeftHorizontalAxis), Input.GetAxisRaw(m_sLeftVerticalAxis)); // Get the axises the player is using.
        m_moveVel = moveInput.normalized * m_fSpeed; // Move velocity.
    }
}
