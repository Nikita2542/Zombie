using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Slizator : MonoBehaviour
{
    public GunOptionsMain GunOptionsMain;
    
    public Text sliz_yellow_text;
    

    [SerializeField]
    public ParticleSystem slizat_part;

    [SerializeField]
    public Material slizator_mat_1;
    public Material slizator_mat_2;
    public Material slizator_mat_3;
    public Material slizator_mat_4;
    public Material slizator_mat_5;
    public Material slizator_mat_6;
    public Material slizator_mat_7;
    public Material slizator_mat_8;
    public Material slizator_mat_9;
    public Material slizator_mat_10;

    

    public int sliz_yellow_main;
    private int sliz_green_main;
    private int slizator_true;

    public void Start()
    {
       
        slizat_part.Stop();
        slizator_true = 0;
        PlayerPrefs.SetInt("slizator_true", slizator_true);
        slizator_mat_1.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_2.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_3.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_4.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_5.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_6.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_7.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_8.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_9.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
        slizator_mat_10.SetColor("_EmissionColor", new Color(255, 255, 255) / 200);
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
            slizator_true = 1;
            PlayerPrefs.SetInt("slizator_true", slizator_true);
        }
        if (GunOptionsMain.gunAvtomat == true)
        {          
            slizator_true = 2;
        }
        if (slizator_true == 1)
        {
            if (Input.GetMouseButtonUp(1))
            {
                slizat_part.Stop();
            }
            if (Input.GetMouseButtonDown(1))
            {
                slizat_part.Play();
            }
        }

        if (PlayerPrefs.HasKey("slizator_true"))
        {
            slizator_true = PlayerPrefs.GetInt("slizator_true");
        }

        
        if (PlayerPrefs.HasKey("sliz_green"))
        {
            sliz_green_main = PlayerPrefs.GetInt("sliz_green");
        }
        
        

        PlayerPrefs.SetInt("sliz_yellow_main", sliz_yellow_main);
        PlayerPrefs.SetInt("sliz_green_main", sliz_green_main);

        PlayerPrefs.Save();
        
        if (sliz_yellow_main >= 1)
        {
            slizator_mat_6.SetColor("_EmissionColor", new Color(191, 81, 0) / 200);           
        }
        if (sliz_yellow_main >= 2)
        {
            slizator_mat_7.SetColor("_EmissionColor", new Color(191, 81, 0) / 200);            
        }
        if (sliz_yellow_main >= 3)
        {
            slizator_mat_8.SetColor("_EmissionColor", new Color(191, 81, 0) / 200);           
        }
        if (sliz_yellow_main >= 4)
        {
            slizator_mat_9.SetColor("_EmissionColor", new Color(191, 81, 0) / 200);            
        }
        if (sliz_yellow_main >= 5)
        {
            slizator_mat_10.SetColor("_EmissionColor", new Color(191, 81, 0) / 200);            
        }      
    }
}
