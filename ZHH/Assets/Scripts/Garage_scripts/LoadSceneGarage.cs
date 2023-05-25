using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGarage : MonoBehaviour
{
    public void EventLoadGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
