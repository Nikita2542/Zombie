using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelButtonController : MonoBehaviour
{
    public WeaponWheelController ammo;
    public GunOptionsMain gunMain;
    
    public int ID;
    [HideInInspector]
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public bool selected = false;
    public Sprite icon;
    public bool activ;
    
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
            
            selectedItem.sprite = icon;
            itemText.text = itemName;
            
        }
        if(activ == true )
        {
            if (ID == 1)
            {
                ActivateGun();
            }
            if (ID == 2)
            {
                ActivateSlizator();
            }
            if(ID == 3)
            {
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
        gunMain.slizatorActiv = false;
        ammo.craftActive = false;
    }
    public void ActivateSlizator()
    {
        gunMain.slizatorActiv = true;
        gunMain.gunActiv = false;
        ammo.craftActive = false;
    }
    public void ActivateCraft()
    {
        ammo.craftActive = true;
        gunMain.slizatorActiv = false;
        gunMain.gunActiv = true;
    }
}
