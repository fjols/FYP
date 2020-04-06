using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    public float m_speed; // Movement speed.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * m_speed; // Move the game object.
    }
}
