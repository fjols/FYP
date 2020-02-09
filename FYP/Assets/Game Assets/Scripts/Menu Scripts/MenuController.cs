using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string button;
    public string scene;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown(button))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
