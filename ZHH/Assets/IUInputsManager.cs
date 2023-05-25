using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class IUInputsManager : MonoBehaviour
{
    [HideInInspector]public WeaponWheelController Weapon;
    public TextMeshProUGUI inputText;
    private bool Active = false; 
    void Start()
    {
        
        Weapon = GetComponentInChildren<WeaponWheelController>();
        inputText.text = Weapon.key.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Active == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Weapon.key = KeyCode.Tab;              
                inputText.text = Weapon.key.ToString();               
                Active = false;
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Weapon.key = KeyCode.Q;              
                inputText.text = Weapon.key.ToString();               
                Active = false;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Weapon.key = KeyCode.R;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Weapon.key = KeyCode.LeftAlt;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Weapon.key = KeyCode.Space;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Weapon.key = KeyCode.G;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Weapon.key = KeyCode.E;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Weapon.key = KeyCode.F;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.ScrollLock))
            {
                Weapon.key = KeyCode.ScrollLock;
                inputText.text = Weapon.key.ToString();
                Active = false;
            }


        }
        
    }

    public void Selected()
    {
        
        inputText.text = "";
               
        Active = true;

    }
    public void Deselected()
    {

    }

    public void HoverEnter()
    {
        
        
    }
    public void HoverExit()
    {

    }
    
}
