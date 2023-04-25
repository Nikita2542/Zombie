using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ScriptsInstruction : MonoBehaviour
{
    public Image imageW;
    public Image imageA;
    public Image imageS;
    public Image imageD;
    public Image imageF;
    public Image imageR;
    public Image image1;
    public Image imageSpace;
    public Image imageLight;
    public Image imageMouseMain; 
    public Image imageMouseLeft;
    public Image imageMouseRite;
    
    public GameObject liggtHint;
    public GameObject driveHint;
    public GameObject mouseHint;
    public GameObject targetHint;
    public GameObject MainInstraction;
    public GameObject KnopkaR;
    public GameObject Knopka1;

    private int chang_Drive;
    private int chang_Light;
    private int chang_Mouse;
    private int chang_Target;
    private int chang_Main;
    private int KnopR;
    private int chang_MouseRite;    
    private int sliz_yellow;
    
    void Start()
    {
        imageR.gameObject.SetActive(false);
        liggtHint.SetActive(false);
        driveHint.SetActive(false);
        mouseHint.SetActive(false);
        targetHint.SetActive(false);
        MainInstraction.SetActive(true);
        KnopkaR.SetActive(false);
        Knopka1.SetActive(false);

        imageMouseMain.color = Color.gray;
        
        chang_Main = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("sliz_yellow_main"))
        {
            sliz_yellow = PlayerPrefs.GetInt("sliz_yellow_main");
        }
        if (PlayerPrefs.HasKey("chang_Main"))
        {
            chang_Main = PlayerPrefs.GetInt("chang_Main");
        }
        if (PlayerPrefs.HasKey("KnopkaR"))
        {
            KnopR = PlayerPrefs.GetInt("KnopkaR");
        }
        if(KnopR == 1)
        {
            imageR.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                imageR.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                imageR.gameObject.SetActive(false);
                imageR.color = Color.white;
                chang_MouseRite = 1;
                KnopR = 0;
                PlayerPrefs.SetInt("KnopkaR", KnopR);
            }
        }
        if(chang_MouseRite == 1)
        {           
            mouseHint.SetActive(true);
            KnopkaR.SetActive(true);
            imageMouseLeft.color = Color.gray;
            imageMouseMain.color = Color.gray;
            if (Input.GetMouseButtonDown(1))
            {
                imageMouseRite.color = Color.gray;

            }
            if (Input.GetMouseButtonDown(1))
            {
                KnopkaR.SetActive(false);
                mouseHint.SetActive(false);
                imageMouseRite.color = Color.white;
                chang_MouseRite = 0;                
            }
        }
        if(sliz_yellow == 2)
        {
            Knopka1.SetActive(false);
        }
        if(sliz_yellow == 1)
        {
            Knopka1.SetActive(true);
            if (Input.GetKeyDown("1"))
            {
                image1.color = Color.gray;
            }
            if (Input.GetKeyUp("1"))
            {
                image1.color = Color.white;
            }
        }
        if(chang_Main == 1)
        {
            MainInstraction.SetActive(false);
            driveHint.SetActive(false);
        }
        if (chang_Main == 0)
        {
            
            if (chang_Light >= 3)
            {
                chang_Drive = 0;
                liggtHint.SetActive(false);
                mouseHint.SetActive(true);
            }
            if (chang_Mouse >= 4)
            {
                chang_Light = 0;
                mouseHint.SetActive(false);
                targetHint.SetActive(true);
            }
            if (chang_Drive >= 5)
            {
                driveHint.SetActive(false);
                liggtHint.SetActive(true);
            }

            if (chang_Target >= 1)
            {
                chang_Mouse = 0;
                chang_Main = 1;
                targetHint.SetActive(false);
                MainInstraction.SetActive(false);
                PlayerPrefs.SetInt("chang_Main", chang_Main);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                imageF.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                chang_Target++;
                imageF.color = Color.white;
            }
            if (Input.GetMouseButtonDown(0))
            {
                imageMouseLeft.color = Color.gray;
            }
            if (Input.GetMouseButtonUp(0))
            {
                chang_Mouse++;
                imageMouseLeft.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                imageLight.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                chang_Light++;
                imageLight.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                imageW.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                chang_Drive++;
                imageW.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                imageA.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                chang_Drive++;
                imageA.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                imageS.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                chang_Drive++;
                imageS.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                imageD.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                chang_Drive++;
                imageD.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                imageSpace.color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                chang_Drive++;
                imageSpace.color = Color.white;
            }
        }        
    }
}
