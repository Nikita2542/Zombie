using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMain : MonoBehaviour
{
    public GameObject ImageLoadGame;
    public GameObject LoadSceneMainMenu;

    public int LoadSceneGame;
    
    public void Start()
    {
        ImageLoadGame.SetActive(false);
        LoadSceneMainMenu.SetActive(false);

        LoadSceneGame = 0;
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadSceneMainMenu.SetActive(true);
        }

            if (LoadSceneGame == 1)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                SceneManager.LoadScene(1);               
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            LoadSceneGame = 1;
            ImageLoadGame.SetActive(true);
              
        }
    }

    public void EventLoadGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
