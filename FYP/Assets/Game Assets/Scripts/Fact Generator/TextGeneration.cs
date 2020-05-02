using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
THIS CLASS WILL GENERATE RANDOM FACTS ON THE MAIN MENU.
*/
public class TextGeneration : MonoBehaviour
{
    [Tooltip("Fill out with space facts!")]
    public string[] m_facts; // Array of facts to use.
    [Tooltip("Foreground text component that displays space fact text.")]
    public Text m_factText; // Text which will display the fact.
    [Tooltip("Background text component that displays space fact text.")]
    public Text m_backgroundText; // Text behind the text. (Creates a depth).
    [Tooltip("The button which changes the facts.")]
    public string m_button; // button to generate facts.

    void Update()
    {
        if(Input.GetButtonDown(m_button)) // If the set button is pressed.
        {
            m_factText.text = m_facts[Random.Range(0, m_facts.Length)]; // Set a random fact.
            m_backgroundText.text = m_factText.text;
        }
    }

}
