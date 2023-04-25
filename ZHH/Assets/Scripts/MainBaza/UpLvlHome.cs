using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpLvlHome : MonoBehaviour
{
    public int sokGreen;
    public int sokYellow;
    public int sokRed;
    public int sokMain;
    public int homeLvl;

    public int homeUpLvl;

    

    public Text textSokGreen;
    public Text textSokYellow;
    public Text textSokRed;
    public Text textSokMain;
    public Text texthomeLvl;

    public Text textHomeUpLvl;

    public Slider sliderHomeLvl;

    public GameObject BtnGrid;
    public GameObject BtnGridBuilding;

    public GameObject MainLab;
    

    public Camera CamLab;
    public Camera CamGrid;


    // Start is called before the first frame update
    void Start()
    {
        BtnGrid.SetActive(true);
        BtnGridBuilding.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("sliz_green_main"))
        {
            sokGreen = PlayerPrefs.GetInt("sliz_green_main");
        }
        if (PlayerPrefs.HasKey("sliz_yellow_main"))
        {
            sokYellow = PlayerPrefs.GetInt("sliz_yellow_main");
        }
        if (PlayerPrefs.HasKey("homeUpLvl"))
        {
            homeUpLvl = PlayerPrefs.GetInt("homeUpLvl");
        }
        if (PlayerPrefs.HasKey("homeLvl"))
        {
            homeLvl = PlayerPrefs.GetInt("homeLvl");
        }
        if (PlayerPrefs.HasKey("sokMain"))
        {
            sokMain = PlayerPrefs.GetInt("sokMain");
        }

        

        PlayerPrefs.Save();

        textSokGreen.text = sokGreen.ToString();
        textSokYellow.text = sokYellow.ToString();
        textSokRed.text = sokRed.ToString();
        textSokMain.text = sokMain.ToString();
        texthomeLvl.text = homeLvl.ToString() + "Lv";

        textHomeUpLvl.text = sokMain.ToString() + "/" + homeUpLvl.ToString();

        sliderHomeLvl.maxValue = homeUpLvl;
        sliderHomeLvl.value = sokMain;
    }

    public void EventConvertSokGreen()
    {
        if(sokGreen >= 3)
        {
            sokMain = sokMain + 1;
            sokGreen = sokGreen - 3;
            PlayerPrefs.SetInt("sliz_green_main", sokGreen);
            PlayerPrefs.SetInt("sokMain", sokMain);

        }
    }
    public void EventConvertSokYellow()
    {
        if (sokYellow >= 2)
        {
            sokMain = sokMain + 1;
            sokYellow = sokYellow - 2;
            PlayerPrefs.SetInt("sliz_yellow_main", sokYellow);
            PlayerPrefs.SetInt("sokMain", sokMain);
        }
    }
    public void EventConvertSokRed()
    {
        if (sokRed >= 1)
        {
            sokMain = sokMain + 1;
            sokRed = sokRed - 1;
        }
    }

    public void EventUpLvlHome()
    {
        if(sokMain >= homeUpLvl)
        {
            homeLvl++;            
            sokMain = sokMain - homeUpLvl;
            homeUpLvl = homeUpLvl * 2;
            PlayerPrefs.SetInt("homeUpLvl", homeUpLvl);
            PlayerPrefs.SetInt("homeLvl", homeLvl);
            PlayerPrefs.SetInt("sokMain", sokMain);
        }
    }

    public void EventGrinOpen()
    {
        CamLab.enabled = false;
        CamGrid.enabled = true;
        MainLab.SetActive(false);
        BtnGrid.SetActive(false);
        BtnGridBuilding.SetActive(true);
    }
    public void EventGridExite()
    {
        CamLab.enabled = true;
        CamGrid.enabled = false;
        MainLab.SetActive(true);
        BtnGrid.SetActive(false);
        BtnGridBuilding.SetActive(false);
    }
}
