using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WeaponWheelButtonController : MonoBehaviour
{
    [Header("ID")]
    public int ID;
    public string itemName;

    [Header("������� �����")]
    public TextMeshProUGUI itemText;
    [Header("������� ������ �����������")]
    public Image ImageBack;

    [Header("�������")]
    public GunOptionsMain gunMain;
  
    [Header("������")]
    public Sprite icon;

    public Image selectedItem;

    [Header("��������� ������ �� ����")]
    public float distantText;
    [Header("��������� ����������� �� ����")]
    public float distantImage;
    [HideInInspector] public WeaponWheelController ammo;
    [HideInInspector] private Animator anim;
    [HideInInspector] public bool selected = false;
    [HideInInspector] public bool activ;
    
    void Start()
    {
         
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
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantText, gameObject.transform.position.y, gameObject.transform.position.z);
                selectedItem.sprite = icon;
                ActivateGun();
            }
            if (ID == 2)
            {
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantText, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivateSlizator();
            }
            if(ID == 3)
            {
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantText, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivateCraft();
            }
            if (ID == 4)
            {
                ImageBack.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantImage, gameObject.transform.position.y, gameObject.transform.position.z);
                itemText.gameObject.transform.position = new Vector3(gameObject.transform.position.x - distantText, gameObject.transform.position.y, gameObject.transform.position.z);
                ActivatePulemet();
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
        gunMain.slizatorActiv = false;
        ammo.craftActive = false;
        gunMain.PulemetActiv = false;
    }
    public void ActivateSlizator()
    {
        gunMain.slizatorActiv = true;
        gunMain.gunActiv = false;
        ammo.craftActive = false;
        gunMain.PulemetActiv = false;
    }
    public void ActivateCraft()
    {
        ammo.craftActive = true;
        gunMain.slizatorActiv = false;
        gunMain.gunActiv = true;
        gunMain.PulemetActiv = false;
    }
    public void ActivatePulemet()
    {
        
        gunMain.PulemetActiv = true;
        ammo.craftActive = false;
        gunMain.slizatorActiv = false;
        gunMain.gunActiv = false;

    }
}
