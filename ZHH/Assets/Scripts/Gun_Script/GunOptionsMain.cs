using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOptionsMain : MonoBehaviour
{
    [Header("������")]
    public GameObject[] gunAll;
    [Header("�����")]
    public GameObject[] textGun;

    [Header("������ ��� ��������")]
    public Gun_Zombie avtomatZombie;
    [Header("������ ��� ��������")]
    public Gun_Zombie pulemetZombie ;
    [Header("������ ��� ���������")]
    public Gun_Zombie sniperZombie;

    [HideInInspector] public bool gunAvtomat;
    [HideInInspector] public bool gunSlizator;
    [HideInInspector] public bool gunPulemet;
    [HideInInspector] public bool gunSniper;

    [HideInInspector] public bool gunActiv;
    [HideInInspector] public bool slizatorActiv;
    [HideInInspector] public bool PulemetActiv;
    [HideInInspector] public bool sniperActiv;


    // Start is called before the first frame update
    void Start()
    {
        textGun[0].SetActive(true);
        textGun[1].SetActive(false);
        textGun[2].SetActive(false);
        textGun[3].SetActive(false);
        gunAll[0].gameObject.SetActive(true);
        gunAll[1].gameObject.SetActive(false);
        gunAll[2].gameObject.SetActive(false);
        gunAll[3].gameObject.SetActive(false);
        gunAvtomat = false;
        gunSlizator = false;
        gunPulemet = false;
        gunSniper = false;



    }

    // Update is called once per frame
    void Update()
    {



        if (gunActiv == true)
        {
            avtomatZombie.enabled = true;
            pulemetZombie.enabled = false;
            sniperZombie.enabled = false;
            gunAll[0].gameObject.SetActive(true);
            textGun[0].gameObject.SetActive(true);

            gunAll[1].gameObject.SetActive(false);
            textGun[1].gameObject.SetActive(false);
            gunAll[2].gameObject.SetActive(false);
            textGun[2].gameObject.SetActive(false);

            gunAll[3].gameObject.SetActive(false);
            textGun[3].gameObject.SetActive(false);

            gunAvtomat = true;
            gunSlizator = false;
            gunPulemet = false;
            gunSniper = false;
        }
       
        if (slizatorActiv == true)
        {
            
            gunAll[1].gameObject.SetActive(true);
            textGun[1].gameObject.SetActive(true);
            
            gunAll[0].gameObject.SetActive(false);
            textGun[0].gameObject.SetActive(false);

            gunAll[2].gameObject.SetActive(false);
            textGun[2].gameObject.SetActive(false);

            gunAll[3].gameObject.SetActive(false);
            textGun[3].gameObject.SetActive(false);

            gunSlizator = true;
            gunAvtomat = false;
            gunPulemet = false;
            gunSniper = false;

        }
       if(PulemetActiv == true)
        {
            avtomatZombie.enabled = false;
            pulemetZombie.enabled = true;
            sniperZombie.enabled = false;
            gunAll[2].gameObject.SetActive(true);
            textGun[2].gameObject.SetActive(true);

            gunAll[0].gameObject.SetActive(false);
            textGun[0].gameObject.SetActive(false);

            gunAll[1].gameObject.SetActive(false);
            textGun[1].gameObject.SetActive(false);

            gunAll[3].gameObject.SetActive(false);
            textGun[3].gameObject.SetActive(false);

            gunPulemet = true;
            gunAvtomat = false;
            gunSlizator = false;
            gunSniper = false;
        }
        if (sniperActiv == true)
        {
            //- ������ - TRUE ---------------------------
            sniperZombie.enabled = true;

            //- ������ - False ---------------------------
            avtomatZombie.enabled = false;
            pulemetZombie.enabled = false;
            
            //- ������ - TRUE ---------------------------
            gunAll[3].gameObject.SetActive(true);      

            //- ������� - FALSE ---------------------------
            gunAll[0].gameObject.SetActive(false);
            gunAll[1].gameObject.SetActive(false);
            gunAll[2].gameObject.SetActive(false);

            //- ����� - TRUE ---------------------------
            textGun[3].gameObject.SetActive(true);

            //- ����� - FALSE ---------------------------
            textGun[0].gameObject.SetActive(false);           
            textGun[1].gameObject.SetActive(false);
            textGun[2].gameObject.SetActive(false);

            gunSniper = true;
            gunPulemet = false;
            gunAvtomat = false;
            gunSlizator = false;
        }
    }
}
