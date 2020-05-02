using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    [Tooltip("The text to type out.")]
    public string m_message; // The message to be displayed.
    [Tooltip("The text to type to.")]
    public Text m_text; // Text component.
    [Tooltip("How fast to type the text.")]
    public float m_typingSpeed; // Speed that the text will be displayed.
    [Tooltip("How much time to wait for before typing.")]
    public float m_fTime;
    
    void Awake()
    {
        m_text = GetComponent<Text>();
        m_message = m_text.text;
        m_text.text = "";
        StartCoroutine("TypeText"); // Start the coroutine.
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(m_fTime);
        foreach(char character in m_message)
        {
            m_text.text += character; // Add character to the text component.
            yield return new WaitForSeconds(m_typingSpeed); // Wait for this amount of time before adding another one.
        }
    }
}
