using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBazaScene : MonoBehaviour
{   
    public GameObject ImageLoadBaza;
    public int LoadSceneBaza;
    public GameObject Mesh;
    public void Start()
    {
        
        ImageLoadBaza.SetActive(false);
      
    }
    public void Update()
    {
        if (LoadSceneBaza == 1)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                
                SceneManager.LoadScene(2);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadSceneBaza = 1;                    
            ImageLoadBaza.SetActive(true);
      }
    }

}
