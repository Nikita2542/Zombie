using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Sale_Shop : MonoBehaviour
{
    public Image locked;
    public Button shop;
    public TextMeshProUGUI text;

    public Button button;

    public int neoShop;
    public int neo;
    void Start()
    {
        button.interactable = false;
        text.text = neoShop.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shop()
    {
        if (neo >= neoShop)
        {
            locked.gameObject.SetActive(false);
            shop.gameObject.SetActive(false);
            button.interactable = true;
        }
        
    }
}
