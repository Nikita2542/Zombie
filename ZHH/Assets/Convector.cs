using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Convector : MonoBehaviour
{
    private UpgrateLaboratory upLab;

    [Header("С.О.К")]
    public int greenSok;
    public int greenSokConvector;

    [Header("Текст")]
    public TextMeshProUGUI textGreen;
    public TextMeshProUGUI textGreenConvector;

    [Header("Замки")]
    public GameObject lockBlue;
    void Start()
    {
        lockBlue.gameObject.SetActive(true);
        upLab = GetComponentInParent<UpgrateLaboratory>();
    }

   
    void Update()
    {
        if(upLab.blueActive == true)
        {
            lockBlue.gameObject.SetActive(false);
        }
        textGreen.text = greenSok.ToString();
        textGreenConvector.text = "X" + greenSokConvector.ToString();
    }

    public void Convect()
    {
        if(upLab.sokGreen >= greenSok)
        {
            upLab.sokGreen -= greenSok;
            upLab.sokGreenConv += greenSokConvector;
        }
    }
    public void ConvectAll()
    {
        if (upLab.sokGreen >= greenSok)
        {
            upLab.sokGreenConv = upLab.sokGreen / greenSok * greenSokConvector;
            float d = upLab.sokGreen / greenSok;
            for(int i = 0; i < d; i++)
            {
                upLab.sokGreen -= greenSok;
            }            
        }
    }


}
