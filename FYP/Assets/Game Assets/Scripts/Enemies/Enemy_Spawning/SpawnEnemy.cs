/*
    AUTHOR: Charlie Jenkinson P17178401.
    This class spawns enemies using a gameobject which is placed in the level but has no sprite attached so you cannot see it.
    It randomises vector values and spawns enemies using the position generated.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int m_iEnemyAmount; // Amount of enemies allowed to be alive at one time.
    public static int m_iCurrentEnemyCount = 0; // Amount of enemies on the screen.
    public GameObject m_enemy; // Enemy to spawn.
    public GameObject m_enemyTwo; // Enemy to spawn.
    private List<GameObject> m_enemyArray; // A list of enemy gameobjects.
    private Vector2 m_enemyPosition; // Position of the enemy.
    void Start()
    {
        m_enemyArray = new List<GameObject>(); // Initialise the list.
        m_enemyArray.Add(m_enemy);
        m_enemyArray.Add(m_enemyTwo);
    }

    void Update()
    {
        if(m_iCurrentEnemyCount < m_iEnemyAmount)
        {
            m_enemyArray.Add(Instantiate(m_enemyArray[Random.Range(0, 2)], RandomizePosition(), m_enemy.transform.rotation)); // Add the spawned enemies to the list so they can be tracked and removed when killed.
            m_iCurrentEnemyCount++; // Add the enemy count.
        }
    }

    Vector3 RandomizePosition()
    {
        m_enemyPosition.x = Random.Range(-8, 8); // Randomise the x position.
        m_enemyPosition.y = Random.Range(5, 10); // Randomise the y positon.
        return m_enemyPosition; // Return the vector with the randomised values.
    }
}

/*
* TODO:
* Make it so enemies are removed from the list when they are destroyed.
Need to link this script with the appropriate enemy scripts to make this happen.
*/