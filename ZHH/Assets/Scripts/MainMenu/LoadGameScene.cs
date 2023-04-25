using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
   public void EventLoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void EventExiteGameScene()
    {
        Application.Quit();
    }
}
