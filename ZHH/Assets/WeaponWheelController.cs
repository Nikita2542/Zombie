
using TMPro;
using UnityEngine;

using UnityEngine.UI;




public class WeaponWheelController : MonoBehaviour
{
    public OptionsScriptUI options;
    public Gun_Zombie gunZombie;

    public KeyCode key;
    
    public int weaponID;
    private bool weaponWheelSelected = false;    
    public float timeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;
    public int saleSlizz;
    public int saleAmmo;
    private int sliz_yellow;
    private float secundomer;
    
    public Animator anim;
    public TextMeshProUGUI ammoText;
    public Image cyrcleImage;
    public GameObject mainFarmUI;
    
    public bool craftActive;

    public void Start()
    {       
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;

        craftActive = false;
        ammoText.text = "X" + saleAmmo.ToString();
        mainFarmUI.gameObject.SetActive(false);
        cyrcleImage.fillAmount = 0;
    }

    void Update()
    {
        if(options.activeOptions == false)
        {
            StopSlowMotion();
            Debug.Log(Input.mousePosition);


            if (Input.GetKey(key))
            {
                StartSlowMotion();
                weaponWheelSelected = true;
                
                
                
                Cursor.lockState = CursorLockMode.Confined;
                
                

            }           
            
            if (Input.GetKeyUp(key))
            {              
                StopSlowMotion();
                weaponWheelSelected = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if(options.activeOptions == true)
        {
            StartSlowMotion();
        }
        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }
        if (PlayerPrefs.HasKey("sliz_yellow"))
        {
            sliz_yellow = PlayerPrefs.GetInt("sliz_yellow");
        }
        if (craftActive == true)
        {
            mainFarmUI.gameObject.SetActive(true);
            if (sliz_yellow >= saleSlizz)
            {
                if (Input.GetMouseButton(1))
                {
                    if (secundomer < 0.2f)
                    {
                        secundomer += Time.deltaTime;
                        cyrcleImage.gameObject.SetActive(true);

                        if (cyrcleImage.fillAmount < 1)
                        {

                            cyrcleImage.fillAmount += Time.deltaTime / 0.2f;
                        }
                    }
                    if (secundomer > 0.2f)
                    {
                        if (cyrcleImage.fillAmount >= 1f)
                        {
                            gunZombie.OptionGun.puliAll += saleAmmo;
                            sliz_yellow -= saleSlizz;
                            PlayerPrefs.SetInt("sliz_yellow", sliz_yellow);
                            cyrcleImage.fillAmount = 0;
                            secundomer = 0;
                        }

                        cyrcleImage.gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {

            mainFarmUI.gameObject.SetActive(false);
        }
    }
    
    public void InputsActiveQ()
    {
        key = KeyCode.Q;
    }
    public void InputsActiveTab()
    {
        key = KeyCode.Tab;
    }
    public void StartSlowMotion()
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * timeScale;
    }
    public void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}
