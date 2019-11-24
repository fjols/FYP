using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static int m_iScore = 0; // The score the player has gathered by destroying enemies.0
    public static int m_iPlayerOneHealth = 3;
    public static int m_iPlayerTwoHealth = 3;
    public Text scoreText; // The text associated with the score.
    public Text playerOneHealthText; // Player health text.
    public Text playerTwoHealthText; // Player two health text.

    public Text winText;
    public PlayerOneController playerOne;
    public PlayerTwoController playerTwo;

    void Start()
    {
        scoreText.text = "Score: " + m_iScore;
        winText.text = "";
        playerOneHealthText.text = "Health: " + m_iPlayerOneHealth;
        playerTwoHealthText.text = "Health: " + m_iPlayerTwoHealth;
    }
    public void IncreaseScore()
    {
        Debug.Log("IncreaseScore method ran.");
        m_iScore += 1; // Increment the score.
        scoreText.text = "Score: " + m_iScore.ToString(); // Update the text with the score value.
    }

    void Update()
    {
        if(Input.GetButtonDown(playerOne.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
            SpawnEnemy.m_iCurrentEnemyCount = 0;
            m_iScore = 0;
        }
        else if(Input.GetButtonDown(playerTwo.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
            SpawnEnemy.m_iCurrentEnemyCount = 0;
            m_iScore = 0;
        }
        scoreText.text = "Score: " + m_iScore.ToString(); // Update the text with the score value.
    }

}
