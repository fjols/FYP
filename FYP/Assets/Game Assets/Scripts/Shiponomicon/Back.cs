using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    [Tooltip("This is the scene to go to.")]
    public string m_sScene; // The scene to load.
    [Tooltip("This is the buton which activates the scene change.")]
    public string m_sButton; // Button which will activate the scene change.

    public void GoBack()
    {
        if(Input.GetButtonDown(m_sButton))
        {
            SceneManager.LoadScene(m_sScene);
        }
    }

}
