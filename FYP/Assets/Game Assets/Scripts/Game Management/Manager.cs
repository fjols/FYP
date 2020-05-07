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
    public Text backgroundText; // Scores background text.
    public Text playerOneHealthText; // Player health text.
    public Text playerTwoHealthText; // Player two health text.


    public Text winText;
    public PlayerOneController playerOne;
    public PlayerTwoController playerTwo;

    void Start()
    {
       // scoreText.text = "Score: " + m_iScore;
      //  winText.text = "";
       // playerOneHealthText.text = "Health: " + m_iPlayerOneHealth;
       // playerTwoHealthText.text = "Health: " + m_iPlayerTwoHealth;
    }
    public void IncreaseScore()
    {
        Debug.Log("IncreaseScore method ran.");

       scoreText.text = "Score: " + m_iScore.ToString(); // Update the text with the score value.
       backgroundText.text = scoreText.text;
    }

    void Update()
    {
       // RestartGame();
        scoreText.text = "Score: " + m_iScore.ToString(); // Update the text with the score value.
        backgroundText.text = scoreText.text;
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1);
    }

/*
    void RestartGame()
    {
        if(Input.GetButtonDown(playerOne.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
            SpawnEnemy.m_iCurrentEnemyCount = -3;
            PowerUpSpawning.m_sCurrentPowerups = -3;
            m_iScore = 0;
        }
        else if(Input.GetButtonDown(playerTwo.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
            SpawnEnemy.m_iCurrentEnemyCount = -3;
            PowerUpSpawning.m_sCurrentPowerups = -3;
            m_iScore = 0;
        }
    }*/

}
