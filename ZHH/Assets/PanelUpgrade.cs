using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static Unity.Burst.Intrinsics.Arm;
using System.Globalization;

public class PanelUpgrade : MonoBehaviour
{
    public UpgrateLaboratory labUp;
    public Upgrade up;

    public GameObject panelUpgrade;
    #region private Obj
    private Image neo;
    private TextMeshProUGUI textNeo;
    private Image fon;
    private Image sok; 

    private Image neo5x;
    private TextMeshProUGUI textNeo5x;
    private Image fon5x;
    private Image sok5x;
    private Image convect;

    private Image ammo;
    private TextMeshProUGUI textAmmo;
    private Image fonAmmo;
    private Image ammoLvl;
    private GameObject ammo1lv;
    private GameObject ammo2lv;
    private GameObject ammo3lv;
    private GameObject ammo4lv;
    #endregion

    void Start()
    {
        #region obj
        panelUpgrade = gameObject;

        neo = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        textNeo = neo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        fon = neo.transform.GetChild(1).GetComponent<Image>();
        sok = neo.transform.GetChild(2).GetComponent<Image>();

        neo5x = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        textNeo5x = neo5x.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        fon5x = neo5x.transform.GetChild(1).GetComponent<Image>();
        sok5x = neo5x.transform.GetChild(2).GetComponent<Image>();
        convect = sok5x.transform.GetChild(1).GetComponent <Image>();

        ammo = gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        textAmmo = ammo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        fonAmmo = ammo.transform.GetChild(1).GetComponent<Image>();
        ammoLvl = ammo.transform.GetChild(2).GetComponent<Image>();
        ammo1lv = ammoLvl.transform.GetChild(0).gameObject;
        ammo2lv = ammoLvl.transform.GetChild(1).gameObject;
        ammo3lv = ammoLvl.transform.GetChild(2).gameObject;
        ammo4lv = ammoLvl.transform.GetChild(3).gameObject;
        #endregion

        labUp = GetComponentInParent<UpgrateLaboratory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(up.labLvl == 2)
        {
            Lvl1();
        }
        if (up.labLvl == 3)
        {
            Lvl2();
        }
        if (up.labLvl == 4)
        {
            Lvl3();
        }
        if (up.labLvl == 5)
        {
            Lvl4();
        }
    }
    private void Lvl1()
    {
        //Neo  
        fon.color = new Color(0, 1, 1, 0.3f);// Голубой цвет
        sok.color = new Color(0, 1, 1, 1);
        //Neo 5x        
        fon5x.color = new Color(0.5f, 1, 0.5f, 0.3f);// Зеленый цвет
        sok5x.color = new Color(0.5f, 1, 0.5f, 1);
        textNeo5x.color = new Color(0.5f, 1, 0.5f, 1);
        //Ammo
        ammo.gameObject.SetActive(false);
       
    }
    private void Lvl2()
    {
        //Neo
        
        fon.color = new Color(1, 0.3f, 0.3f, 0.3f);// Красный цвет
        sok.color = new Color(1, 0.3f, 0.3f, 1);
        //Neo 5x             
        fon5x.color = new Color(0, 1, 1, 0.3f);// Голубой цвет
        sok5x.color = new Color(0, 1, 1, 1);
        textNeo5x.color = new Color(0, 1, 1, 1);
        //Ammo
        ammo.gameObject.SetActive(true);    
        fonAmmo.color = new Color(0, 1, 1, 0.3f);// Голубой цвет
        ammoLvl.color = new Color(0, 1, 1, 1);
        ammo1lv.SetActive(false); ammo2lv.SetActive(true); ammo3lv.SetActive(false); ammo4lv.SetActive(false);
    }
    private void Lvl3()
    {
        //Neo
        fon.color = new Color(0, 0, 0, 0.3f);// Черный цвет
        sok.color = new Color(0, 0, 0, 1);
        //Neo 5x
        fon5x.color = new Color(1, 0.3f, 0.3f, 0.3f);// Красный цвет
        sok5x.color = new Color(1, 0.3f, 0.3f, 1);
        textNeo5x.color = new Color(1, 0.3f, 0.3f, 1);
        //Ammo
        ammo.gameObject.SetActive(true);
        fonAmmo.color = new Color(1, 0.3f, 0.3f, 0.3f);// Красный цвет
        ammoLvl.color = new Color(1, 0.3f, 0.3f, 1);
        ammo1lv.SetActive(false); ammo2lv.SetActive(false); ammo3lv.SetActive(true); ammo4lv.SetActive(false);
    }
    private void Lvl4()
    {
        //Neo
        neo.gameObject.SetActive(false);     
        //Neo 5x
        fon5x.color = new Color(0, 0, 0, 0.3f);// Черный цвет
        sok5x.color = new Color(0, 0, 0, 1);
        textNeo5x.color = new Color(0, 0, 0, 1);
        convect.color = new Color(1, 0, 0, 1);
        //Ammo
        ammo.gameObject.SetActive(true);
        fonAmmo.color = new Color(0, 0, 0, 0.3f);// Черный цвет
        ammoLvl.color = new Color(0, 0, 0, 1);
        ammo1lv.SetActive(false); ammo2lv.SetActive(false); ammo3lv.SetActive(false); ammo4lv.SetActive(true);
    }


    public void Close()
    {
        panelUpgrade.gameObject.SetActive(false);
    }
    public void Convector()
    {
        panelUpgrade.gameObject.SetActive(false);

        labUp.BtnConvector.gameObject.SetActive(false);
        labUp.BtnUpgrade.gameObject.SetActive(false);

        labUp.upgrade.gameObject.SetActive(false);

        labUp.convector.gameObject.SetActive(true);
    }
    public void Gun()
    {
        SceneManager.LoadScene(1);
        panelUpgrade.gameObject.SetActive(false);
    }
}
