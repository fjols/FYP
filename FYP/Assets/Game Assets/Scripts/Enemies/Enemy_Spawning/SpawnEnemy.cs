using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private int m_iEnemyAmount = 10; // Amount of enemies allowed to be alive at one time.
    private int m_iCurrentEnemyCount= 0;
    public GameObject m_enemy; // Enemy to spawn.
    private Vector3 m_enemyPosition; // Position of the enemy.
    void Start()
    {
        
    }

    void Update()
    {
        if(m_iCurrentEnemyCount < m_iEnemyAmount)
        {
            Instantiate(m_enemy, RandomizePosition(), m_enemy.transform.rotation);
            m_iCurrentEnemyCount++;
        }
    }

    Vector3 RandomizePosition()
    {
        m_enemyPosition.x = Random.Range(-8, 8);
        m_enemyPosition.y = Random.Range(5, 10);
        m_enemyPosition.z = 0;
        return m_enemyPosition;
    }
}
