using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOptionsMain : MonoBehaviour
{
    //[Header("������")]
     public GameObject[] gunAll;

    //[Header("�����")]
    [HideInInspector] public GameObject[] textGun;

    //[Header("������ ��� ��������")]
    [HideInInspector] public Gun_Zombie avtomatZombie;
    //[Header("������ ��� ��������")]
    [HideInInspector] public Gun_Zombie pulemetZombie ;
    //[Header("������ ��� ���������")]
    [HideInInspector] public Gun_Zombie sniperZombie;

    //[Header("������ ��� ��������")]
    [HideInInspector] public WeaponRecoil avtomatRecoil;
    //[Header("������ ��� ��������")]
    [HideInInspector] public WeaponRecoil pulemetRecoil;
    //[Header("������ ��� ���������")]
    [HideInInspector] public WeaponRecoil sniperRecoil;

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
        // - ������� ������� �� ���� -
        gunAll[0] = GameObject.FindGameObjectWithTag("Avtomat");
        gunAll[1] = GameObject.FindGameObjectWithTag("Slizator");
        gunAll[2] = GameObject.FindGameObjectWithTag("Pulemet");
        gunAll[3] = GameObject.FindGameObjectWithTag("Sniper");
        // - ������� ������� �� ���� -
        textGun[0] = GameObject.FindGameObjectWithTag("Avtomat Text");
        textGun[1] = GameObject.FindGameObjectWithTag("Slizator Text");
        textGun[2] = GameObject.FindGameObjectWithTag("Pulemet Text");
        textGun[3] = GameObject.FindGameObjectWithTag("Sniper Text");
        // - ���������� � �������� ������� �� ������� ������ -
        avtomatZombie = gunAll[0].GetComponentInParent<Gun_Zombie>();
        pulemetZombie = gunAll[2].GetComponentInParent<Gun_Zombie>();
        sniperZombie = gunAll[3].GetComponentInParent<Gun_Zombie>();

        // - ���������� � �������� ������� �� ������� ������ -
        avtomatRecoil = gunAll[0].GetComponentInParent<WeaponRecoil>();
        pulemetRecoil = gunAll[2].GetComponentInParent<WeaponRecoil>();
        sniperRecoil = gunAll[3].GetComponentInParent<WeaponRecoil>();

        textGun[0].SetActive(true);
        textGun[1].SetActive(false);
        textGun[2].SetActive(false);
        textGun[3].SetActive(false);

        gunAll[0].gameObject.SetActive(true);
        gunAll[1].gameObject.SetActive(false);
        gunAll[2].gameObject.SetActive(false);
        gunAll[3].gameObject.SetActive(false);

        gunAvtomat = true;
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

            avtomatRecoil.enabled = true;
            pulemetRecoil.enabled = false;
            sniperRecoil.enabled = false;
            
            


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

            avtomatRecoil.enabled = false;
            pulemetRecoil.enabled = true;
            sniperRecoil.enabled = false;
            
                

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

            avtomatRecoil.enabled = false;
            pulemetRecoil.enabled = false;
            sniperRecoil.enabled = true;
            
                

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
