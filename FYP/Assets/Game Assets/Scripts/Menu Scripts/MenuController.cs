using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string button;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown(button))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
