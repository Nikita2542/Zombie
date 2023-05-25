using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Rendering;

public class UpgrateLaboratory : MonoBehaviour
{
    [Header("C.O.K")]
    #region SOK & NEO
    public int sokGreen;
    public int sokBlue;
    public int sokRed;
    public int sokBlack;

    [Header("Н.Е.О")]
    public int neoGreen;
    public int neoBlue;
    public int neoRed;
    public int neoBlack;
    #endregion

    [Header("Текст")]
    public TextMeshProUGUI[] textSok;
    public TextMeshProUGUI[] textNeo;

    [Header("Play")]
    public Button play;

    [Header("Конвектор")]
    public Button BtnConvector;    
    public GameObject convector;

    [Header("Улучшение")]
    public Button BtnUpgrade;
    public GameObject upgrade;

    public bool blueActive;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        #region GetInt
        sokGreen = PlayerPrefs.GetInt("sokGreen");
        sokBlue = PlayerPrefs.GetInt("sokBlue");
        sokRed = PlayerPrefs.GetInt("sokRed");
        sokBlack = PlayerPrefs.GetInt("sokBlack");

        neoGreen = PlayerPrefs.GetInt("neoGreen");
        neoBlue = PlayerPrefs.GetInt("neoBlue");
        neoRed = PlayerPrefs.GetInt("neoRed");
        neoBlack = PlayerPrefs.GetInt("neoBlack");
        #endregion

        #region SetInt
        PlayerPrefs.SetInt("sokGreen", sokGreen);
        PlayerPrefs.SetInt("sokBlue", sokBlue);
        PlayerPrefs.SetInt("sokRed", sokRed);
        PlayerPrefs.SetInt("sokBlack", sokBlack);

        PlayerPrefs.SetInt("neoGreen", neoGreen);
        PlayerPrefs.SetInt("neoBlue", neoBlue);
        PlayerPrefs.SetInt("neoRed", neoRed);
        PlayerPrefs.SetInt("neoBlack", neoBlack);
        #endregion

        convector.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);

        BtnConvector.gameObject.SetActive(true);
        BtnUpgrade.gameObject.SetActive(true);  

    }

    // Update is called once per frame
    void Update()
    {
        textSok[0].text = sokGreen.ToString();
        textNeo[0].text = neoGreen.ToString();

        textSok[1].text = sokBlue.ToString();
        textNeo[1].text = neoBlue.ToString();

        textSok[2].text = sokRed.ToString();
        textNeo[2].text = neoRed.ToString();

        textSok[3].text = sokBlack.ToString();
        textNeo[3].text = neoBlack.ToString();
    }

    public void Upgrade()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void Convector()
    {
        play.gameObject.SetActive(false);
        BtnConvector.gameObject.SetActive(false);
        BtnUpgrade.gameObject.SetActive(false);
        convector.gameObject.SetActive(true);
    }

    public void UpgradeBtn()
    {
        play.gameObject.SetActive(false);
        BtnConvector.gameObject.SetActive(false);
        BtnUpgrade.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(true);
    }

    public void BackTrue()
    {
        play.gameObject.SetActive(true);

        BtnConvector.gameObject.SetActive(true);
        BtnUpgrade.gameObject.SetActive(true);

        convector.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);
    }

}
