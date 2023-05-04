using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOptionsMain : MonoBehaviour
{
    [Header("Оружие")]
    public GameObject[] gunAll;
    [Header("Текст")]
    public GameObject[] textGun;

    [HideInInspector] public bool gunAvtomat;
    [HideInInspector] public bool gunSlizator;

    [HideInInspector] public bool gunActiv;
    [HideInInspector] public bool slizatorActiv;


    // Start is called before the first frame update
    void Start()
    {
        textGun[0].SetActive(true);
        textGun[1].SetActive(false);
        gunAll[0].gameObject.SetActive(true);
        gunAll[1].gameObject.SetActive(false);
        gunAvtomat = false;
        gunSlizator = false;



    }

    // Update is called once per frame
    void Update()
    {



        if (gunActiv == true)
        {
            
            gunAll[0].gameObject.SetActive(true);
            textGun[0].gameObject.SetActive(true);

            gunAll[1].gameObject.SetActive(false);
            textGun[1].gameObject.SetActive(false);
            gunAvtomat = true;
            gunSlizator = false;
        }
       
        if (slizatorActiv == true)
        {
            
            gunAll[1].gameObject.SetActive(true);
            textGun[1].gameObject.SetActive(true);
            
            gunAll[0].gameObject.SetActive(false);
            textGun[0].gameObject.SetActive(false);
            gunSlizator = true;
            gunAvtomat = false;

        }
       
    }
}
