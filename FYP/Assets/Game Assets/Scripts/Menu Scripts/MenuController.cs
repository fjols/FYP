using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public string button;
    public string scene;

    public void LoadLANGame()
    {
        loadScene(scene);
    }
    
    public void LoadGame()
    {
        loadScene(scene);
    }
    
    public void LoadShiponomicon()
    {
        loadScene(scene);
    }

    public void LoadEnemyOne()
    {
        loadScene(scene);
    }

    public void LoadEnemyTwo()
    {
        loadScene(scene);
    }

    public void LoadEnemyThree()
    {
        loadScene(scene);
    }

    public void LoadBoss()
    {
        loadScene(scene);
    }

    public void LoadSamePCGame()
    {
        loadScene(scene);
    }

    void loadScene(string scene_)
    {
        scene_ = scene;
        if(Input.GetButtonDown(button))
        {
            SceneManager.LoadScene(scene_);
        }
    }
}
