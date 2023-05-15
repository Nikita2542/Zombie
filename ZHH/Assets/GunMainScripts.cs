using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunMainScripts : MonoBehaviour
{
    public GameObject[] Guns;
    
    public bool avtomat, pulemet, sniper;

    public bool Active_pricel;
    public bool Active_glushak;
    public bool Active_otdacha;
    public bool Active_boezapas;
    
    public Camera Camera_glavnaya;

    public GameObject Orujie_off;
    ////// Значки /////
    public GameObject plusik;
    
    [Header("Прицел")]
    public GameObject Target_pricel;
    public GameObject LookAt_pricel;
   
    [Header("Главная камера к оружию")]
    public GameObject Target_camera;
    public GameObject LookAt_orujie;

    [Header("Глушитель")]
    public GameObject Target_glushak;
    public GameObject LookAt_glushak;

    [Header("Отдача")]
    public GameObject Target_otdacha;
    public GameObject LookAt_otdacha;

    [Header("Боезапас")]
    public GameObject Target_boezapas;
    public GameObject LookAt_boezapas;



    public int Manager;
   

    void Start()
    {
        avtomat = false; pulemet = false; sniper = false;
        Camera_glavnaya.enabled = true;
        
        Orujie_off.SetActive(true);
        plusik.SetActive(false);
       

        Active_pricel = false;
        Active_glushak = false;
        Active_otdacha = false;
        Active_boezapas = false;
    }

    void Update()
    {
        // Автомат
        if( avtomat == true)
        {
            Guns[0].gameObject.SetActive(true);
            
        }
        else
        {
            Guns[0].gameObject.SetActive(false);
        }

        // Пулемет
        if (pulemet == true)
        {
            Guns[1].gameObject.SetActive(true);  
        }
        else
        {
            Guns[1].gameObject.SetActive(false);
        }

        // Снайпа
        if (sniper == true)
        {
            Guns[2].gameObject.SetActive(true);
            Orujie_off.SetActive(false);
            plusik.gameObject.SetActive(true);

        }
        else
        {
            Guns[2].gameObject.SetActive(false);
        }
        if (Manager == 1)
        {
            if (Active_pricel == false)
            {
                Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_camera.transform.position, Time.deltaTime * 2);
                Camera_glavnaya.transform.LookAt(LookAt_orujie.transform);
                
            }
            else
            {
                EventPricel();
                plusik.gameObject.SetActive(false);
            }
            
            if (Active_glushak == false)
            {
                Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_camera.transform.position, Time.deltaTime * 2);
                Camera_glavnaya.transform.LookAt(LookAt_orujie.transform);


            }
            else
            {
                EventGlushak();
                plusik.gameObject.SetActive(false);
            }
            
            if (Active_otdacha == false)
            {
                Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_camera.transform.position, Time.deltaTime * 2);
                Camera_glavnaya.transform.LookAt(LookAt_orujie.transform);


            }
            else
            {
                EventGlushak();
                plusik.gameObject.SetActive(false);
            }

            if (Active_boezapas == false)
            {
                Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_camera.transform.position, Time.deltaTime * 2);
                Camera_glavnaya.transform.LookAt(LookAt_orujie.transform);


            }
            else
            {
                EventBoezapas();
                plusik.gameObject.SetActive(false);
            }
        }
        if (Manager == 0)
        {
            Camera_1();
        }
        
    }

    public void ActivateAvtomat()
    {
        avtomat = true;

        pulemet = false; sniper = false;
        Manager = 1;
    }
    public void ActivatePulemet()
    {
        pulemet = true;

        avtomat = false; sniper = false;
        Manager = 1;
    }
    public void ActivateSniper()
    {
        sniper = true;

        avtomat = false; pulemet = false;
        Manager = 1;
    }
    void Camera_1()
    {
        Camera_glavnaya.enabled = true;
       
    }
   public void EventPricel()
    {
        Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_pricel.transform.position, Time.deltaTime * 2);
        Camera_glavnaya.transform.LookAt(LookAt_pricel.transform);
        Active_pricel = true;
    }
  
        
    public void EventGlushak()
    {
        Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_glushak.transform.position, Time.deltaTime * 2);
        Camera_glavnaya.transform.LookAt(LookAt_glushak.transform);
        Active_glushak = true;
        
    }

    public void EventOtdacha()
    {
        Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_otdacha.transform.position, Time.deltaTime * 2);
        Camera_glavnaya.transform.LookAt(LookAt_otdacha.transform);
        Active_otdacha = true;

    }
    public void EventBoezapas()
    {
        Camera_glavnaya.transform.position = Vector3.Lerp(Camera_glavnaya.transform.position, Target_boezapas.transform.position, Time.deltaTime * 2);
        Camera_glavnaya.transform.LookAt(LookAt_boezapas.transform);
        Active_boezapas = true;

    }
}

