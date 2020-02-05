using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-   THIS SCRIPT IS FOR MAKING PLAYER BULLETS FASTER WHEN THEY PICK UP THE POWERUP.
*/

public class FasterBullet : MonoBehaviour
{
    public Powerup _powerup;
    public float m_fSpeedIncrease; // How much to increase the speed of the bullet by.
   // PlayerBullet bulletOne;
    

    void Start()
    {
    //    bulletOne = new PlayerBullet();
//        m_fSpeedIncrease = _powerup.speedIncrease;
    }

    
    void Update()
    {
        
    }

    public void IncreaseSpeed(float _speedIncrease)
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
           // bulletOne.SpeedIncrease(m_fSpeedIncrease);
            Destroy(gameObject);
        }
    }
}
