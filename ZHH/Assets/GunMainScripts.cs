using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMainScripts : MonoBehaviour
{
    public GameObject[] Guns;

    public bool avtomat, pulemet, sniper;

    void Start()
    {
        avtomat = false; pulemet = false; sniper = false;
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
        }
        else
        {
            Guns[2].gameObject.SetActive(false);
        }
    }

    public void ActivateAvtomat()
    {
        avtomat = true;

        pulemet = false; sniper = false;
    }
    public void ActivatePulemet()
    {
        pulemet = true;

        avtomat = false; sniper = false;
    }
    public void ActivateSniper()
    {
        sniper = true;

        avtomat = false; pulemet = false;
    }
}
