using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScriptUI : MonoBehaviour
{
    public GameObject optionsCanva;
    public bool activeOptions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        optionsCanva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(activeOptions == false)
            {
                Pause();
            }
            else
            {
                Returne();
            }
        }
    }

    public void Pause()
    {
        
        optionsCanva.SetActive(true);
        activeOptions = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void Returne()
    {
        optionsCanva.SetActive(false);
        activeOptions = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
