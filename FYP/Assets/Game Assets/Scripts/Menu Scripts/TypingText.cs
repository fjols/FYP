using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    public string m_message; // The message to be displayed.
    public Text m_text; // Text component.
    public float m_typingSpeed; // Speed that the text will be displayed.
    
    void Awake()
    {
        m_text = GetComponent<Text>();
        m_message = m_text.text;
        m_text.text = "";
        StartCoroutine("TypeText"); // Start the coroutine.
    }

    IEnumerator TypeText()
    {
        foreach(char character in m_message)
        {
            m_text.text += character; // Add character to the text component.
            yield return new WaitForSeconds(m_typingSpeed); // Wait for this amount of time before adding another one.
        }
    }
}
