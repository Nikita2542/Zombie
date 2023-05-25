using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Upgrade : MonoBehaviour
{
    private UpgrateLaboratory upLab;
    public Convector conv;
    [Header("С.О.К")]
    public int up;

    [Header("LVL")]
    public int labLvl;
    public int labLvlUp;
    [Header("Панель апгрейда")]
    public GameObject panelUpgrade;

    [Header("Текст")]
    public TextMeshProUGUI textLabLvl;
    public TextMeshProUGUI textLabLvlUp;
    [Space(20)]
    public TextMeshProUGUI textUp;
    public Image sokUp;

    [Header("Lvl")]
    public GameObject lvl;
    #region lvl Components
    private Image openAmmo;//Глава
    private Image dustAmmo;
    private GameObject Ammo1lv;
    private GameObject Ammo2lv;
    private GameObject Ammo3lv;
    private GameObject Ammo4lv;

    private Image openSok;//Глава
    private Image dustSok;

    private Image openSok5x;//Глава
    private Image dustSok5x;
    private Image convect;
    private TextMeshProUGUI text5x;
    #endregion

    void Start()
    {
        
        sokUp = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        textUp = sokUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        #region lvl Component
        openAmmo = lvl.transform.GetChild(0).GetComponent<Image>();//Глава
        dustAmmo = openAmmo.transform.GetChild(0).GetComponent<Image>();
        Ammo1lv = openAmmo.transform.GetChild(1).gameObject;
        Ammo2lv = openAmmo.transform.GetChild(2).gameObject;
        Ammo3lv = openAmmo.transform.GetChild(3).gameObject;
        Ammo4lv = openAmmo.transform.GetChild(4).gameObject;

        openSok = lvl.transform.GetChild(1).GetComponent<Image>();//Глава
        dustSok = openSok.transform.GetChild(0).GetComponent<Image>();

        openSok5x = lvl.transform.GetChild(2).GetComponent<Image>();//Глава
        dustSok5x = openSok5x.transform.GetChild(0).GetComponent<Image>();
        convect = openSok5x.transform.GetChild(1).GetComponent<Image>();
        text5x = openSok5x.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        #endregion

        panelUpgrade.gameObject.SetActive(false);
        upLab = GetComponentInParent<UpgrateLaboratory>();
        openAmmo.gameObject.SetActive(false);
        dustAmmo.gameObject.SetActive(false);

    }

    private void Lvl1()
    {
       // openAmmo.color = new Color(0, 1, 1, 1);// Голубой цвет
       // dustAmmo.color = new Color(0, 1, 1, 1);
        
        Ammo1lv.SetActive(true); Ammo2lv.SetActive(false); Ammo3lv.SetActive(false); Ammo4lv.SetActive(false);

        openSok.color = new Color(0, 1, 1, 1);// Голубой цвет
        dustSok.color = new Color(0, 1, 1, 1);

        openSok5x.color = new Color(0.5f, 1, 0.5f, 1);// Зеленый цвет
        dustSok5x.color = new Color(0.5f, 1, 0.5f, 1);
        text5x.color = new Color(0.5f, 1, 0.5f, 1);
    }
    private void Lvl2()
    {
        openAmmo.gameObject.SetActive(true);
        dustAmmo.gameObject.SetActive(true);
        openAmmo.color = new Color(0, 1, 1, 1);// Голубой цвет
        dustAmmo.color = new Color(0, 1, 1, 1);
        Ammo1lv.SetActive(false); Ammo2lv.SetActive(true); Ammo3lv.SetActive(false); Ammo4lv.SetActive(false);

        openSok.color = new Color(1, 0.3f, 0.3f, 1);// Красный цвет
        dustSok.color = new Color(1, 0.3f, 0.3f, 1);

        openSok5x.color = new Color(0, 1, 1, 1);// Голубой цвет
        dustSok5x.color = new Color(0, 1, 1, 1);
        text5x.color = new Color(0, 1, 1, 1);
    }
    private void Lvl3()
    {
        openAmmo.color = new Color(1, 0.3f, 0.3f, 1);// Красный цвет
        dustAmmo.color = new Color(1, 0.3f, 0.3f, 1);
        Ammo1lv.SetActive(false); Ammo2lv.SetActive(false); Ammo3lv.SetActive(true); Ammo4lv.SetActive(false);

        openSok.color = new Color(0, 0, 0, 1);// Черный цвет
        dustSok.color = new Color(0, 0, 0, 1);

        openSok5x.color = new Color(1, 0.3f, 0.3f, 1);// Красный цвет
        dustSok5x.color = new Color(1, 0.3f, 0.3f, 1);
        text5x.color = new Color(1, 0.3f, 0.3f, 1);
    }
    private void Lvl4()
    {
        openAmmo.color = new Color(0, 0, 0, 1);// Красный цвет
        dustAmmo.color = new Color(0, 0, 0, 1);
        Ammo1lv.SetActive(false); Ammo2lv.SetActive(false); Ammo3lv.SetActive(false); Ammo4lv.SetActive(true);

        openSok.gameObject.SetActive(false);
        dustSok.gameObject.SetActive(false);
        //openSok.color = new Color(0, 0, 0, 1);// Черный цвет
        //dustSok.color = new Color(0, 0, 0, 1);

        openSok5x.color = new Color(0, 0, 0, 1);// Красный цвет
        dustSok5x.color = new Color(0, 0, 0, 1);
        convect.color = new Color(1, 0, 0, 1);
        text5x.color = new Color(0, 0, 0, 1);
    }


    private void LVL()
    {
        if (labLvl == 1)
        {
            Lvl1();
            
        }
        if (labLvl == 2)
        {
            Lvl2();
            conv.lockBlue[0].gameObject.SetActive(false);
        }
        if (labLvl == 3)
        {
            Lvl3();
            conv.lockBlue[1].gameObject.SetActive(false);
        }
        if (labLvl == 4)
        {
            Lvl4();
            conv.lockBlue[2].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        LVL();

        textLabLvl.text = labLvl.ToString() + " lv";
        textLabLvlUp.text = labLvlUp.ToString() + " lv";

        textUp.text = up.ToString();
    }
    public void LvlUp()
    {
        if (upLab.neoGreen >= up)
        {
            if (labLvl == 1)
            {
                sokUp.color = new Color(0, 1, 1, 1);
                textUp.color = new Color(0, 1, 1, 1);
                upLab.neoGreen -= up;
                labLvl++; labLvlUp++;
                conv.greenNeo = 5;
                panelUpgrade.gameObject.SetActive(true);     

            }
            
        }
        if (upLab.neoBlue >= up)
        {
            if (labLvl == 2)
            {
                sokUp.color = new Color(1, 0.3f, 0.3f, 1);
                textUp.color = new Color(1, 0.3f, 0.3f, 1);
                upLab.neoBlue -= up;
                labLvl++; labLvlUp++;
                conv.blueNeo = 5;
                panelUpgrade.gameObject.SetActive(true);
            }
           
        }
        if (upLab.neoRed >= up)
        {
            if (labLvl == 3)
            {
                sokUp.color = new Color(0, 0, 0, 1);
                textUp.color = new Color(0, 0, 0, 1);
                upLab.neoRed -= up;
                labLvl++; labLvlUp++;
                conv.redNeo = 5;
                panelUpgrade.gameObject.SetActive(true);
            }
            
        }
        if (upLab.neoBlack >= up)
        {
            if (labLvl == 4)
            {
                sokUp.color = new Color(0, 0, 0, 1);
                textUp.color = new Color(0, 0, 0, 1);
                upLab.neoBlack -= up;
                labLvl++; labLvlUp++;
                conv.blackNeo = 5;
                panelUpgrade.gameObject.SetActive(true);
            }
            
        }
    }
}
