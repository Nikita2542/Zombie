
using TMPro;
using UnityEngine;

using UnityEngine.UI;




public class WeaponWheelController : MonoBehaviour
{


    //[Header("Скрипты")]
    [HideInInspector] public OptionsScriptUI options;
    [HideInInspector] public GunOptionsMain gunMain;
    [HideInInspector] public Gun_Zombie avtomatGun;
    [HideInInspector] public Gun_Zombie pulemetGun;
    [HideInInspector] public Gun_Zombie sniperGun;
    
    public KeyCode key;

    [Header("Продажа")]
    public int saleAmmo;
    public int saleSlizz;

    private int sliz_yellow;
    private float secundomer;
    private float startTimeScale;
    private float startFixedDeltaTime;

    [HideInInspector] public Animator anim;
    [HideInInspector] public TextMeshProUGUI ammoText;
    [HideInInspector] public GameObject mainFarmUI;
    [HideInInspector] public Image cyrcleImage;


    [HideInInspector] public bool craftActive;
    [HideInInspector] public float timeScale;
    private bool weaponWheelSelected = false;
    private bool activeCraft;
    public void Start()
    {
        options = GameObject.FindGameObjectWithTag("Canvas").GetComponentInParent<OptionsScriptUI>();
        gunMain = GameObject.FindGameObjectWithTag("Gun Main").GetComponentInParent<GunOptionsMain>();
        avtomatGun = GameObject.FindGameObjectWithTag("Avtomat Main").GetComponentInParent<Gun_Zombie>();
        pulemetGun = GameObject.FindGameObjectWithTag("Pulemet Main").GetComponentInParent<Gun_Zombie>();
        sniperGun = GameObject.FindGameObjectWithTag("Sniper Main").GetComponentInParent<Gun_Zombie>();
        ammoText = GameObject.FindGameObjectWithTag("Ammo Text").GetComponent<TextMeshProUGUI>();
        mainFarmUI = GameObject.FindGameObjectWithTag("Farm Ammo");
        cyrcleImage = GameObject.FindGameObjectWithTag("Image Cyrcle").GetComponent<Image>();
        anim = GetComponent<Animator>();

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
        if (gunMain.gunActiv == true)
        {
            activeCraft = true;
            CraftActivate();
        }
        if (gunMain.PulemetActiv == true)
        {
            
            CraftActivate();
        }
        if (gunMain.sniperActiv == true)
        {
           
            CraftActivate();
        }

        if (gunMain.gunActiv == true)
        {
            if(activeCraft == true)
            {
                secundomer = 0;
                cyrcleImage.fillAmount = 0;
            }
            
            

        }
        if (gunMain.PulemetActiv == true)
        {
            if (activeCraft == true)
            {
                secundomer = 0;
                cyrcleImage.fillAmount = 0;
            }

        }
        if (gunMain.sniperActiv == true)
        {
            if (activeCraft == true)
            {
                secundomer = 0;
                cyrcleImage.fillAmount = 0;
            }

        }
    }
    
       
    
    

    public void CraftActivate()
    {
       
        if (craftActive == true)
        {
            activeCraft = false;
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
                            if(gunMain.gunActiv == true)
                            {
                                avtomatGun.OptionGun.puliAll += saleAmmo;
                                sliz_yellow -= saleSlizz;
                            }
                            if (gunMain.PulemetActiv == true)
                            {
                                pulemetGun.OptionGun.puliAll += saleAmmo;
                                sliz_yellow -= saleSlizz;
                            }
                            if (gunMain.sniperActiv == true)
                            {
                                sniperGun.OptionGun.puliAll += saleAmmo;
                                sliz_yellow -= saleSlizz;
                            }


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
