using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private int m_fScore = 0; // The score the player has gathered by destroying enemies.0
    public Text scoreText; // The text associated with the score.
    public Controller playerOne;
    public Controller playerTwo;

    void Start()
    {
        scoreText.text = "Score: " + m_fScore;
    }
    public void IncreaseScore()
    {
        Debug.Log("IncreaseScore method ran.");
        m_fScore += 1; // Increment the score.
        scoreText.text = "Score: " + m_fScore.ToString(); // Update the text with the score value.
    }

    void Update()
    {
        if(Input.GetButtonDown(playerOne.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
        }
        else if(Input.GetButtonDown(playerTwo.m_sResetButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reset the scene.
        }
    }

}
