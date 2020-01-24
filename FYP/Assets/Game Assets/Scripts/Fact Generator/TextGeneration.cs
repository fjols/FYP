using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
THIS CLASS WILL GENERATE RANDOM FACTS ON THE MAIN MENU.
*/
public class TextGeneration : MonoBehaviour
{
    
    public string[] m_facts; // Array of facts to use.
    public Text m_factText; // Text which will display the fact.
    public string m_button; // button to generate facts.
    void Update()
    {
        if(Input.GetButtonDown(m_button)) // If the set button is pressed.
        {
            m_factText.text = m_facts[Random.Range(0, m_facts.Length)]; // Set a random fact.
        }
    }
}
