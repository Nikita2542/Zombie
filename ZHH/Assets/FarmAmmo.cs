using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmAmmo : MonoBehaviour
{
    public Gun_Zombie gunZombie;
    private bool farmAmmoActive;
    private int sliz_yellow;
    public int saleSlizz;
    public int saleAmmo;

    
    public Text slizzSaleText;
    public Text ammoSaleText;

    public Image imageCyrcle;
    public GameObject farmUI;

    private float secundomer;
    // Start is called before the first frame update
    void Start()
    {
        farmAmmoActive = false;
        farmUI.gameObject.SetActive(false);
        imageCyrcle.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        slizzSaleText.text = saleSlizz.ToString();
        ammoSaleText.text = saleAmmo.ToString();
        if (PlayerPrefs.HasKey("sliz_yellow"))
        {
            sliz_yellow = PlayerPrefs.GetInt("sliz_yellow");
        }
        if (farmAmmoActive == true)
        {
           
            farmUI.gameObject.SetActive(true);
            if(sliz_yellow > 0)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    if (secundomer < 1)
                    {
                        secundomer += Time.deltaTime;
                        imageCyrcle.gameObject.SetActive(true);
                        if (imageCyrcle.fillAmount < 1)
                        {
                            imageCyrcle.fillAmount += Time.deltaTime / 1;
                        }
                    }
                    if (secundomer > 1)
                    {

                        if (imageCyrcle.fillAmount >= 1)
                        {
                            gunZombie.OptionGun.puliAll += saleAmmo;
                            sliz_yellow -= saleSlizz;
                            PlayerPrefs.SetInt("sliz_yellow", sliz_yellow);
                            imageCyrcle.fillAmount = 0;
                            secundomer = 0;
                        }
                        imageCyrcle.gameObject.SetActive(false);
                    }

                }

            }
            
        
               
        }
        else
        {
            farmUI.gameObject.SetActive(false);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            farmAmmoActive = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            farmAmmoActive = false;
        }
    }
}
