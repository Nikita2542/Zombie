using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Rendering;

public class UpgrateLaboratory : MonoBehaviour
{
    [Header("C.O.K")]
    public float sokGreen;
    [HideInInspector] public float sokBlue;
    [HideInInspector] public float sokRed;

    [HideInInspector] public float sokGreenConv;
    [HideInInspector] public float sokBlueConv;
    [HideInInspector] public float sokRedConv;

    [Header("Текст")]
    public TextMeshProUGUI textGreenMain;
    public TextMeshProUGUI textGreenConvertMain;

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
        convector.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);

        BtnConvector.gameObject.SetActive(true);
        BtnUpgrade.gameObject.SetActive(true);  

    }

    // Update is called once per frame
    void Update()
    {
        textGreenMain.text = sokGreen.ToString();
        textGreenConvertMain.text = sokGreenConv.ToString(); 
    }

    public void Upgrade()
    {
        
    }
   
   
    public void Convector()
    {
        BtnConvector.gameObject.SetActive(false);
        BtnUpgrade.gameObject.SetActive(false);
        convector.gameObject.SetActive(true);
    }

    public void UpgradeBtn()
    {
        BtnConvector.gameObject.SetActive(false);
        BtnUpgrade.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(true);
    }

    public void BackTrue()
    {
        BtnConvector.gameObject.SetActive(true);
        BtnUpgrade.gameObject.SetActive(true);

        convector.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);
    }

}
