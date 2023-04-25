using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ligt_Shitok : MonoBehaviour
{
    public Light[] lite;
    
    public GameObject Image_Ligt_Shitok;
    public int liteyy = 0;
    
    void Start()
    {
        Image_Ligt_Shitok.SetActive(false);
    }

    void Update()
    {
        if (liteyy == 1)
        {
            
            
            if (Input.GetKey("q"))
            {
                for (int i = 0; i < lite.Length; i += 1)
                {
                    lite[i].intensity = 60;
                }

                
                
            }
        }                  
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Player"))
        {
            liteyy = 1;           
            Image_Ligt_Shitok.SetActive(true);           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            liteyy = 0;
            Image_Ligt_Shitok.SetActive(false);
        }
    }
}
