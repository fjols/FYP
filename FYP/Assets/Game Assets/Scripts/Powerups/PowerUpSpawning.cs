using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int m_iPowerupAmount;
    public static int m_sCurrentPowerups;
    public GameObject m_powerUp;
    private Vector2 m_pos;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    Vector3 PowerUpPosition()
    {
        m_pos.x = Random.Range(-8, 8); // Randomise the x position.
        m_pos.y = Random.Range(5, 10); // Randomise the y positon.
        return m_pos;
    }
}
