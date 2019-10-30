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

    private Shake shake; // Shake class object. (Shake.cs).
    public GameObject camContainer; // Gameobject which contains the camera.
    public float shakeStrength = 0.1f;
    Animator m_anim; // The animator component.
    private bool m_bDead = false; // Is the player dead.

    void Awake()
    {
        shake = camContainer.GetComponent<Shake>(); // Get the component of the Shake class.
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // Get the component.
        m_anim = GetComponent<Animator>(); // Get the animator component.
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

    void OnCollisionEnter2D(Collision2D col)
    {

        m_bDead = true; // Set it to true it will play the death animation.
        m_fSpeed = 0; // Set speed to 0.
        m_anim.SetBool("Death", m_bDead); // Set the animator to play the animation
        Destroy(gameObject, 1f); // Destroy the enemy after the animations played.
        shake.CameraShake(shakeStrength, 0.5f); // Shake the camera.
    }
}
