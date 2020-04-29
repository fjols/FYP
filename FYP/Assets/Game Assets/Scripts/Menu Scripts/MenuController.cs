using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public string button;
    public string scene;
    bool selected;

    public void LoadLANGame()
    {
        if(Input.GetButtonDown(button))
        {
            SceneManager.LoadScene(scene);
        }
    }
    
    public void LoadGame()
    {
        if(Input.GetButtonDown(button))
        {
                SceneManager.LoadScene(scene);
        }
    }
}
