using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WeaponWheelButtonController : MonoBehaviour
{
    
    public int ID;
    public string itemName;
    public GameObject FarmUI;
    public GameObject itemGameObj;
    public float distantFarm;

    //[Header("Дистанция текста от края")]
    [HideInInspector] public float distantText = 300;
    //[Header("Дистанция изображение от края")]
    [HideInInspector] public float distantImage = 1;

    //[Header("Главный Текст")]
    [HideInInspector] public TextMeshProUGUI itemText;
    //[Header("Главный заднее изображение")]
    [HideInInspector] public Image ImageBack;
    //[Header("Скрипты")]
    [HideInInspector] public GunOptionsMain gunMain;

    [HideInInspector] public WeaponWheelController ammo;
    [HideInInspector] private Animator anim;
    [HideInInspector] public bool selected = false;
    [HideInInspector] public bool activ;
    
    void Start()
    {
        distantText = 300;
        distantImage = 1;
        gunMain = GameObject.FindGameObjectWithTag("Gun Main").GetComponentInParent<GunOptionsMain>();
        ImageBack = GameObject.FindGameObjectWithTag("Image Back").GetComponent<Image>();
        itemText = GameObject.FindGameObjectWithTag("Item Selected Text").GetComponent<TextMeshProUGUI>();
        ammo = GetComponentInParent<WeaponWheelController>();
         anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == true)
        {
            
           
            itemText.text = itemName;
            
        }
        if(activ == true )
        {
            if (ID == 1)
            {
                FarmUI.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantFarm, gameObject.transform.position.y, gameObject.transform.position.z);
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(itemGameObj.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);              
                ActivateGun();
                ActivateCraft();
            }
            if (ID == 2)
            {
                
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(itemGameObj.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivateSlizator();
                
            }
            if(ID == 3)
            {
                FarmUI.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantFarm, gameObject.transform.position.y, gameObject.transform.position.z);
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(itemGameObj.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivateCraft();
            }
            if (ID == 4)
            {
                FarmUI.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantFarm, gameObject.transform.position.y, gameObject.transform.position.z);
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(itemGameObj.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivatePulemet();
                ActivateCraft();
            }
            if (ID == 5)
            {
                FarmUI.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantFarm, gameObject.transform.position.y, gameObject.transform.position.z);
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(itemGameObj.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivateSniper();
                ActivateCraft();
            }
        }
        
    }

    public void Selected()
    {
        
        selected = true;
        
    }
    public void Deselected()
    {
        
        selected = false;
        
    }

    public void HoverEnter()
    {
        activ = true;
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        ammo.craftActive = false;
        activ = false;
        anim.SetBool("Hover", false);
        itemText.text = "";
    }

    public void ActivateGun()
    {
        gunMain.gunActiv = true;

        // - False -
        gunMain.slizatorActiv = false;
        ammo.craftActive = false;
        gunMain.PulemetActiv = false;
        gunMain.sniperActiv = false;
    }
    public void ActivateSlizator()
    {
        gunMain.slizatorActiv = true;

        // - False -
        gunMain.gunActiv = false;
        ammo.craftActive = false;
        gunMain.PulemetActiv = false;
        gunMain.sniperActiv = false;
    }
    public void ActivateCraft()
    {
        ammo.craftActive = true;
        
        if(gunMain.gunActiv == true)
        {
            gunMain.gunActiv = true;
        }
        if (gunMain.PulemetActiv == true)
        {
            gunMain.PulemetActiv = true;
        }
        if (gunMain.sniperActiv == true)
        {
            gunMain.sniperActiv = true;
        }

        // - False -
        gunMain.slizatorActiv = false; 
        
        
    }
    public void ActivatePulemet()
    {
        
        gunMain.PulemetActiv = true;

        // - False -
        ammo.craftActive = false;
        gunMain.slizatorActiv = false;
        gunMain.gunActiv = false;
        gunMain.sniperActiv = false;

    }
    public void ActivateSniper()
    {

        gunMain.sniperActiv = true;

        // - False -
        ammo.craftActive = false;

        gunMain.PulemetActiv = false;    
        gunMain.slizatorActiv = false;
        gunMain.gunActiv = false;

    }
}
