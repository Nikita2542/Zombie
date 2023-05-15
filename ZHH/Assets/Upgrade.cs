using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    private UpgrateLaboratory upLab;
    private Convector conv;
    [Header("�.�.�")]
    public int up;

    [Header("LVL")]
    public int labLvl;
    public int labLvlUp;

    [Header("�����")]
    public TextMeshProUGUI textLabLvl;
    public TextMeshProUGUI textLabLvlUp;
    [Space(20)]
    public TextMeshProUGUI textUp;
    void Start()
    {
        upLab = GetComponentInParent<UpgrateLaboratory>();
        conv = upLab.GetComponentInChildren<Convector>();
    }

    // Update is called once per frame
    void Update()
    {
        textLabLvl.text = labLvl.ToString() + " lv";
        textLabLvlUp.text = labLvlUp.ToString() + " lv";

        textUp.text = up.ToString();
    }
    public void LvlUp()
    {
        if(upLab.sokGreenConv >= up)
        {
            upLab.sokGreenConv -= up;
            up = up * 2;
            labLvl++;
            labLvlUp++;
            upLab.blueActive = true;
        }
       
    }
}
