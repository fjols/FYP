using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawning : MonoBehaviour
{
    public int m_iPowerupAmount; // Amount of powerups allowed at one time.
    public static int m_sCurrentPowerups = 0; // Current amount of powerups on the screen.
    public GameObject m_powerUp; // What to spawn.
    private Vector2 m_pos; // Position of the powerup. 

    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnPowerups(); // Spawn the powerups.
    }

    void SpawnPowerups()
    {
        if(m_sCurrentPowerups < m_iPowerupAmount) // If the amount of power ups on the screen are not the maximum allowed make more.
        {
            Instantiate(m_powerUp, PowerUpPosition(), m_powerUp.transform.rotation); // Instantiate a gameobject.
            m_sCurrentPowerups++; // Increment the amount.
        }
    }

    Vector3 PowerUpPosition()
    {
        m_pos.x = Random.Range(-8, 8); // Randomise the x position.
        m_pos.y = Random.Range(-3, 3); // Randomise the y positon.
        return m_pos; // Return the position.
    }
}
