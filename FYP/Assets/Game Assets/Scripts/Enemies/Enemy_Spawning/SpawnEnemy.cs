/*
    AUTHOR: Charlie Jenkinson P17178401.
    This class spawns enemies using a gameobject which is placed in the level but has no sprite attached so you cannot see it.
    It randomises vector values and spawns enemies using the position generated.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int m_iEnemyAmount = 5; // Amount of enemies allowed to be alive at one time.
    public static int m_iCurrentEnemyCount = 0; // Amount of enemies on the screen.
    public GameObject m_enemy; // Enemy to spawn.
    public GameObject m_enemyTwo; // Enemy to spawn.
    public GameObject m_enemyThree; // Enemy to spawn.
    public float m_fTime; // Time to countdown from.
    public Text m_timeText;
    private List<GameObject> m_enemyArray; // A list of enemy gameobjects.
    private Vector2 m_enemyPosition; // Position of the enemy.
    float elapsedTime;
    void Start()
    {
        m_enemyArray = new List<GameObject>(); // Initialise the list.
        m_enemyArray.Add(m_enemy);
        m_enemyArray.Add(m_enemyTwo);
        m_enemyArray.Add(m_enemyThree);
    }

    void Update()
    {
        //if(Timer(5, false) <= 0.0f) // If the timer hits 0 then start generating enemies.
        //{
            //if(Timer(5, true) >= 5 && m_iEnemyAmount < 5)
           // {
          //      m_enemyArray.Add(Instantiate(m_enemyArray[Random.Range(0, 3)], 
          //        RandomizePosition(), m_enemy.transform.rotation)); // Add the spawned enemies to the list so they can be tracked and removed when killed.
           //     m_iEnemyAmount += 1;
           //     if(Timer(20, true) >= 5)
           //     {
           //         m_iEnemyAmount -= 1;
           //     }
           //     m_iCurrentEnemyCount = m_iEnemyAmount; // Add the enemy count.
           
        //    }
       // }
       Timer(1.0f, true);
    }

    Vector3 RandomizePosition()
    {
        m_enemyPosition.x = Random.Range(-8, 8); // Randomise the x position.
        m_enemyPosition.y = Random.Range(5, 10); // Randomise the y positon.
        return m_enemyPosition; // Return the vector with the randomised values.
    }

    float Timer(float time, bool reset) // Delay the start of the game a bit so players can join.
    {
        elapsedTime += Time.deltaTime; // Count down.
        if(elapsedTime >= time + 1)
        {
            m_enemyArray.Add(Instantiate(m_enemyArray[Random.Range(0, 3)], RandomizePosition(), m_enemy.transform.rotation)); // Add the spawned enemies to the list so they can be tracked and removed when killed.
            if(reset)
            {
                elapsedTime = 0; // Reset the time.
            }
        }
        return elapsedTime; // Return the time value.
    }
}

/*
* TODO:
* Make it so enemies are removed from the list when they are destroyed.
Need to link this script with the appropriate enemy scripts to make this happen.
*/