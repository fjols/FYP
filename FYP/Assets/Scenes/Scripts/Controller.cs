using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed; // Speed of the player
    private Rigidbody2D rb; // Rigidbody2D component.
    private Vector2 moveVel; // Movement velocity.
    private float heading; // Heading angle, used for rotation.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the component.
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVel * Time.fixedDeltaTime); // Move the player.
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("LeftJoystickHorizontal"), -Input.GetAxisRaw("LeftJoystickVertical")); // Get the axises the player is using.
        moveVel = moveInput * speed; // Move velocity.
        heading = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg; // Set the heading angle.
        transform.rotation = Quaternion.AngleAxis(heading, Vector3.forward); // Use the heading angle to rotate the player in the direction they are moving.
    }
}
