using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class ZoomScoupSniper : MonoBehaviour
{
    [Header("Скрипты")]
    public RCC_Camera playerCamera;
    public GunOptionsMain Gun;

    [Header("ПостПроцесс")]
    public Volume postProces;
    

    [Header("Чувствительность")]
    public float sentivity4X;
    public float sentivity8X;

    [Header("Слайдер")]
    public Slider slider4X;
    public Slider slider8X;

    [Header("Текст")]
    public TextMeshProUGUI textX;
    float secText;

    [Header("Камера")]
    public Camera cameraSniper;

    [Header("Приближение")]
    public float scoup4X;
    public float scoup8X;

    [Header("Активация 8X")]
    public bool scoupActive8X;

    void Start()
    {
        ModeDefault();
        scoupActive8X = false;
        textX.gameObject.SetActive(false);
        secText = 1;
        postProces.enabled = false;
    }

   
    void Update()
    {
        if(Gun.sniperActiv == true)
        {
            if (Input.GetMouseButton(1))
            {
                postProces.enabled = true;
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    scoupActive8X = !scoupActive8X;
                    secText = 1;
                }
                if (scoupActive8X)
                {
                    TextEvent();
                    cameraSniper.fieldOfView = scoup8X;
                    ModeScope8X();
                    SliderSensitivityScoup8X();
                }
                else
                {
                    TextEvent();
                    cameraSniper.fieldOfView = scoup4X;
                    ModeScope4X();
                    SliderSensitivityScoup4X();
                }
            }
            if(Input.GetMouseButtonUp(1))
            {
                postProces.enabled = false;
            }
        }
       
        
       

    }
   public void TextEvent()
    {
        
        if (secText > 0)
        {
            textX.gameObject.SetActive(true);

            if (scoupActive8X == false)
            {
                textX.text = "4" + "X";
            }
            if (scoupActive8X == true)
            {
                textX.text = "8" + "X";
            }

            secText -= Time.deltaTime;
        }
        if(secText < 0)
        {
            textX.gameObject.SetActive(false);
            secText = 0;
        }
        

    }
    
    public void ModeDefault()
    {
        slider4X.value = sentivity4X;
        slider8X.value = sentivity8X;
    }
    public void ModeScope4X()
    {
        playerCamera.orbitYSpeed = sentivity4X;
        playerCamera.orbitXSpeed = sentivity4X;
    }
    public void ModeScope8X()
    {
        playerCamera.orbitYSpeed = sentivity8X;
        playerCamera.orbitXSpeed = sentivity8X;
    }
    public void SliderSensitivityScoup4X()
    {
        sentivity4X = slider4X.value;
    }
    public void SliderSensitivityScoup8X()
    {
        sentivity8X = slider8X.value;
    }
}
