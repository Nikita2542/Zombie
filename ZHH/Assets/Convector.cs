using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Convector : MonoBehaviour
{
    private UpgrateLaboratory upLab;
    public Upgrade up;

    [Header("С.О.К")]
    public int greenSok;
    public int greenNeo;

    public int blueSok;
    public int blueNeo;

    public int redSok;
    public int redNeo;

    public int blackSok;
    public int blackNeo;

    [Header("Текст")]
    public TextMeshProUGUI[] textSok;
    public TextMeshProUGUI[] textNeo;

    [Header("Замки")]
    public GameObject[] lockBlue;
    void Start()
    {
        lockBlue[0].gameObject.SetActive(true);
        upLab = GetComponentInParent<UpgrateLaboratory>();
        up = upLab.GetComponentInChildren<Upgrade>();
    }

   
    void Update()
    {
        
        textSok[0].text = greenSok.ToString();
        textNeo[0].text = "X" + greenNeo.ToString();

        textSok[1].text = greenSok.ToString();
        textNeo[1].text = "X" + blueNeo.ToString();

        textSok[2].text = greenSok.ToString();
        textNeo[2].text = "X" + redNeo.ToString();

        textSok[3].text = greenSok.ToString();
        textNeo[3].text = "X" + blackNeo.ToString();

    }

    public void ConvectGreen()
    {
        if(upLab.sokGreen >= greenSok)
        {
            upLab.sokGreen -= greenSok;
            upLab.neoGreen += greenNeo;
        }
    }
    public void ConvectBlue()
    {
        if (upLab.sokBlue >= blueSok)
        {
            upLab.sokBlue -= blueSok;
            upLab.neoBlue += blueNeo;
        }
    }
    public void ConvectRed()
    {
        if (upLab.sokRed >= redSok)
        {
            upLab.sokRed -= redSok;
            upLab.neoRed += redNeo;
        }
    }
    public void ConvectBlack()
    {
        if (upLab.sokBlack >= blackSok)
        {
            upLab.sokBlack -= blackSok;
            upLab.neoBlack += blackNeo;
        }
    }
    public void ConvectAll()
    {
        GreenNeo();
        BlueNeo();
        RedNeo();
        BlackNeo();
    }
    private void GreenNeo()
    {
        if(up.labLvl >= 1)
        {
            if (upLab.sokGreen >= greenSok)
            {
                upLab.neoGreen = (upLab.sokGreen / greenSok * greenNeo) + upLab.neoGreen;
                float d = upLab.sokGreen / greenSok;
                for (int i = 0; i < d; i++)
                {
                    upLab.sokGreen -= greenSok;
                }
            }
        }
    }
    private void BlueNeo()
    {
        if (up.labLvl >= 2)
        {
            if (upLab.sokBlue >= blueSok)
            {
                upLab.neoBlue = (upLab.sokBlue / blueSok * blueNeo) + upLab.neoBlue;
                float d = upLab.sokBlue / blueSok;
                for (int i = 0; i < d; i++)
                {
                    upLab.sokBlue -= blueSok;
                }
            }
        }
    }
    private void RedNeo()
    {
        if (up.labLvl >= 3)
        {
            if (upLab.sokRed >= redSok)
            {
                upLab.neoRed = (upLab.sokRed / redSok * redNeo) + upLab.neoRed;
                float d = upLab.sokRed / redSok;
                for (int i = 0; i < d; i++)
                {
                    upLab.sokRed -= redSok;
                }
            }
        }
    }
    private void BlackNeo()
    {
        if (up.labLvl >= 4)
        {
            if (upLab.sokBlack >= blackSok)
            {
                upLab.neoBlack = (upLab.sokBlack / blackSok * blackNeo) + upLab.neoBlue;
                float d = upLab.sokBlack / blackSok;
                for (int i = 0; i < d; i++)
                {
                    upLab.sokBlack -= blackSok;
                }
            }
        }
    }


}
