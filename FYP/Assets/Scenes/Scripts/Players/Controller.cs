using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float m_fSpeed; // Speed of the player
    private Rigidbody2D rbody; // Rigidbody2D component.
    private Vector2 m_moveVel; // Movement velocity.
    private float m_fheadingAngle; // Heading angle, used for rotation.
    private float m_fRightHeadingAngle;

    public string m_sLeftHorizontalAxis;
    public string m_sLeftVerticalAxis;

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
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(m_sLeftHorizontalAxis), -Input.GetAxisRaw(m_sLeftVerticalAxis)); // Get the axises the player is using.
        m_moveVel = moveInput * m_fSpeed; // Move velocity.
        m_fheadingAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg; // Set the heading angle.
        transform.rotation = Quaternion.AngleAxis(m_fheadingAngle, Vector3.forward); // Use the heading angle to rotate the player in the direction they are moving.
    }
}
