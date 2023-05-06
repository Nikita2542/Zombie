using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOptionsMain : MonoBehaviour
{
    [Header("Оружие")]
    public GameObject[] gunAll;
    [Header("Текст")]
    public GameObject[] textGun;

    [Header("Скрипт для автомата")]
    public Gun_Zombie avtomatZombie;
    [Header("Скрипт для пулемета")]
    public Gun_Zombie pulemetZombie ;

    [HideInInspector] public bool gunAvtomat;
    [HideInInspector] public bool gunSlizator;
    [HideInInspector] public bool gunPulemet;

    [HideInInspector] public bool gunActiv;
    [HideInInspector] public bool slizatorActiv;
    [HideInInspector] public bool PulemetActiv;


    // Start is called before the first frame update
    void Start()
    {
        textGun[0].SetActive(true);
        textGun[1].SetActive(false);
        textGun[2].SetActive(false);
        gunAll[0].gameObject.SetActive(true);
        gunAll[1].gameObject.SetActive(false);
        gunAll[2].gameObject.SetActive(false);
        gunAvtomat = false;
        gunSlizator = false;
        gunPulemet = false;



    }

    // Update is called once per frame
    void Update()
    {



        if (gunActiv == true)
        {
            avtomatZombie.enabled = true;
            pulemetZombie.enabled = false;
            gunAll[0].gameObject.SetActive(true);
            textGun[0].gameObject.SetActive(true);

            gunAll[1].gameObject.SetActive(false);
            textGun[1].gameObject.SetActive(false);
            gunAll[2].gameObject.SetActive(false);
            textGun[2].gameObject.SetActive(false);
            
            gunAvtomat = true;
            gunSlizator = false;
            gunPulemet = false;
        }
       
        if (slizatorActiv == true)
        {
            
            gunAll[1].gameObject.SetActive(true);
            textGun[1].gameObject.SetActive(true);
            
            gunAll[0].gameObject.SetActive(false);
            textGun[0].gameObject.SetActive(false);

            gunAll[2].gameObject.SetActive(false);
            textGun[2].gameObject.SetActive(false);
            
            gunSlizator = true;
            gunAvtomat = false;
            gunPulemet = false;

        }
       if(PulemetActiv == true)
        {
            avtomatZombie.enabled = false;
            pulemetZombie.enabled = true;
            gunAll[2].gameObject.SetActive(true);
            textGun[2].gameObject.SetActive(true);

            gunAll[0].gameObject.SetActive(false);
            textGun[0].gameObject.SetActive(false);
            gunAll[1].gameObject.SetActive(false);
            textGun[1].gameObject.SetActive(false);

            gunPulemet = true;
            gunAvtomat = false;
            gunSlizator = false;
        }
    }
}
