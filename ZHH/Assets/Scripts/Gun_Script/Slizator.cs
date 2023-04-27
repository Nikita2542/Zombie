using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Slizator : MonoBehaviour
{
    GunOptionsMain GunOptionsMain;
    
    public Text sliz_yellow_text;
 
    public ParticleSystem slizat_part;
 
    private int sliz_yellow_main;
    private int sliz_green_main;
    private int slizator_true;

    
    public MaterialSlizator Material;
    [System.Serializable]
    public class MaterialSlizator
    {
        public Material[] matSlizator;
    }

    public void Start()
    {
        
        GunOptionsMain = GetComponentInParent<GunOptionsMain>();
        slizat_part.Stop();
        slizator_true = 0;
        PlayerPrefs.SetInt("slizator_true", slizator_true);
        Material.matSlizator[0].SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        for (int i = 0; i < Material.matSlizator.Length; i++)
        {
            Material.matSlizator[i].SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        }
        
    }
    public void Update()
    {
        if (PlayerPrefs.HasKey("sliz_yellow"))
        {
            sliz_yellow_main = PlayerPrefs.GetInt("sliz_yellow");
        }
        sliz_yellow_text.text = sliz_yellow_main.ToString();
        if (GunOptionsMain.gunSlizator == true)
        {
            if(Material.matSlizator.Length <= sliz_yellow_main)
            {
                for (int i = 0; i < Material.matSlizator.Length; i++)
                {
                    Material.matSlizator[i].SetColor("_EmissionColor", new Color(191, 81, 0) / 200);
                }
            }
           
            slizator_true = 1;
            PlayerPrefs.SetInt("slizator_true", slizator_true);

        }
        else
        {
            slizator_true = 0;
            PlayerPrefs.SetInt("slizator_true", slizator_true);
        }
        
        //if (slizator_true == 1)
        //{
        //    if (Input.GetMouseButtonUp(1))
        //    {
        //        slizat_part.Stop();
        //    }
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        slizat_part.Play();
        //    }
        //}

       

        
        if (PlayerPrefs.HasKey("sliz_green"))
        {
            sliz_green_main = PlayerPrefs.GetInt("sliz_green");
        }
        
        

        PlayerPrefs.SetInt("sliz_yellow_main", sliz_yellow_main);
        PlayerPrefs.SetInt("sliz_green_main", sliz_green_main);

        PlayerPrefs.Save();
        


    }
   
}
