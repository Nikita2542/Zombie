using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class Gun_Zombie : MonoBehaviour
{

    // - Õ¿—“–Œ… ¿  ¿Ã≈–€ --------------------------------------------------------------------------------------------------------------

    public RCC_Camera playerCamera;
    public float damage_gun = 20;
    [HideInInspector]
    public Camera Gun_Camera;
    public OptionGunAvtomat OptionCamera;
    [System.Serializable]
    public class OptionGunAvtomat
    {
        [Range(1, 5)] public float sensitivity = 1;
        [Range(1, 20)] public float sensitivityScope = 1;
        [Range(40, 120)] public float recoil;
        [Range(20, 60)] public float recoilScoup;
        [Range(20, 40)] public float zoom;
        [Range(20, 40)] public float zoomScoup;
        [Range(0, 7)] public float distans;
        [Range(0, 2)] public float distansScoup;
        public float height;
        public float minOrbitY;
        public float maxOrbitY;

        public float minOrbitYScoup;
        public float maxOrbitYScoup;

        public bool openGun;
        public bool openScope;
    }
    


    

   

    // - Õ¿—“–Œ… ¿ Œ–”∆»ﬂ --------------------------------------------------------------------------------------------------------------

    private GunOptionsMain gunOptionsMain;
    public OptionAvtomat OptionGun;
    [System.Serializable]
    public class OptionAvtomat
    {
        
        [Range(0, 30)] public float fireRate = 50f;
        [Range(0, 1000)] public float Last_TargetForce = 40;

        public int bullet;
        public int bulletMax;
        public int puliAll;
        public float reloading;

        
        public float remNoScoup;
        public float remScoup;
    }
    
    Ray ray;
    private float secReload;
    
    private bool nothing;

    // - ƒ–”√Œ≈ ----------------------------------------------------------------------------------------------------------------------------------

    public particle ParticalAll;
    [System.Serializable]
    public class particle
    {
        public Animation anim_Part;
        public ParticleSystem muzzleFlash;
        public ParticleSystem nitro1;
        public ParticleSystem nitro2;
    }
    public UIGun ui;
    [System.Serializable]
    public class UIGun
    {
        public Slider sliderSensitivity;
        public Slider sliderSensitivityScoup;

        public Text textBullet;
        public Text textBulletMax;

        public Image Pricel;
        public GameObject rem;
        public Image imageReloading;

        public AudioClip shotClip;

        public GameObject prefabLastTarget;
    }

    private AudioSource shotAudio;
   
    private GameObject Last_TargetGO;

    private float nextTimeToFire = 0f;
    
    private float range_gun;
  
    private Vector3 directionOn;
    

    private Animator animator;
    [HideInInspector]
    public bool reloadGun;
    [HideInInspector]
    public bool reload;
    // - START -------------------------------------------------------------------------------------------------------------------------
    public void Start()
    {
        gunOptionsMain = GetComponentInParent<GunOptionsMain>();
        Gun_Camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

        ui.imageReloading.fillAmount = 0;
        ui.imageReloading.gameObject.SetActive(false);
        OptionGun.bullet = OptionGun.bulletMax;
        
        

        OptionCamera.openGun = true;
        OptionCamera.openScope = false;

        shotAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        // - «¿ƒ¿≈“ ƒ›‘ŒÀ“Õ€≈ Õ¿—“–Œ… »  ¿Ã≈–€ -
        ModedeDefault();

        if (PlayerPrefs.HasKey("damage_gun_sale"))
        {
            damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
        }
    }
    // - UPDATE GO ---------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        ui.textBulletMax.text = OptionGun.puliAll.ToString();
        if (OptionGun.puliAll <= 0)
        {
            if(OptionGun.bullet <= 0)
            {
                nothing = true;
            }
            
        }

        ui.textBullet.text  = OptionGun.bullet.ToString();

        if(Input.GetKeyDown(KeyCode.R))
        {
            reloadGun = true;
        }
        if(OptionGun.bullet <= 0)
        {
            reloadGun = true;
        }

        // - œ≈–≈«¿–ﬂƒ ¿ - «¿ ŒÕ◊»À»—‹ œ”À» -
        if(reloadGun == true)
        {
            reload = true;
            if (secReload <= OptionGun.reloading)
            {
                if (OptionGun.puliAll > 0)
                {
                    secReload += Time.deltaTime;
                    ui.imageReloading.gameObject.SetActive(true);
                    if (ui.imageReloading.fillAmount < 1)
                    {
                        ui.imageReloading.fillAmount += Time.deltaTime / OptionGun.reloading;
                    }
                }

            }
            if (secReload >= OptionGun.reloading)
            {

                if (OptionGun.puliAll > OptionGun.bulletMax)
                {


                    if (ui.imageReloading.fillAmount >= 1)
                    {
                        nothing = false;
                        OptionGun.puliAll = OptionGun.puliAll - (OptionGun.bulletMax - OptionGun.bullet);
                        OptionGun.bullet = OptionGun.bulletMax;
                        ui.imageReloading.gameObject.SetActive(false);
                        ui.imageReloading.fillAmount = 0;
                        reloadGun = false;
                    }

                }
                if (OptionGun.puliAll < OptionGun.bulletMax)
                {
                    if (ui.imageReloading.fillAmount >= 1)
                    {
                        nothing = false;
                        OptionGun.bulletMax = OptionGun.puliAll;


                        OptionGun.bullet = OptionGun.bulletMax;
                        OptionGun.puliAll -= OptionGun.bulletMax;
                        ui.imageReloading.gameObject.SetActive(false);
                        ui.imageReloading.fillAmount = 0;
                        reloadGun = false;
                    }



                }




                secReload = 0;
            }




        }
        if(reloadGun == false)
        {
            OptionGun.bulletMax = 35;
            reload = false;
        }
        
        
        // - œ–Œ¬≈– ¿ —Œ—“ŒﬂÕ»ﬂ œ–»÷≈À¿ -

        if (Input.GetMouseButton(1))
        {
            ui.rem.gameObject.transform.position = new Vector3(ui.rem.transform.position.x, OptionGun.remScoup, ui.rem.transform.position.z);
            ui.Pricel.gameObject.SetActive(false);
            OptionCamera.openScope = true;
            OptionCamera.openGun = false;
        }
        else
        {
            ui.rem.gameObject.transform.position = new Vector3(ui.rem.transform.position.x, OptionGun.remNoScoup, ui.rem.transform.position.z);
            ui.Pricel.gameObject.SetActive(true);
            OptionCamera.openGun = true;
            OptionCamera.openScope = false;
        }

        // - œ–»÷≈À¿ Õ≈¿ “»¬≈Õ -
        if (gunOptionsMain.gunSlizator == false)
        {
            if (OptionCamera.openGun == true)
            {
                SliderSensitivity();
                ModeOpenGun();

                // - œ≈–≈«¿–ﬂƒ ¿ œ–ŒÿÀ¿ -

                if (nothing == false)
                {
                    if (reload == false)
                    {
                        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
                        {
                            animator.SetBool("Fire", true);
                            OptionGun.bullet = OptionGun.bullet - 1;
                            playerCamera.TPSMinimumFOV = OptionCamera.recoil;

                            shotAudio.PlayOneShot(ui.shotClip);
                            nextTimeToFire = Time.time + 1f / OptionGun.fireRate;
                            Shoot();
                        }
                        if (Input.GetMouseButtonDown(0))
                        {
                            playerCamera.TPSMinimumFOV = OptionCamera.recoil;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            animator.SetBool("Fire", false);
                            playerCamera.TPSMinimumFOV = OptionCamera.zoom;
                        }
                    }
                }
            }
        }
            

        // - œ–»÷≈À¿ ¿ “»¬≈Õ -
        if (gunOptionsMain.gunSlizator == false)
        {
            if (OptionCamera.openScope == true)
            {
                playerCamera.TPSHeight = OptionCamera.height;
                SliderSensitivityScoup();
                ModeOpenScope();

                // - œ≈–≈«¿–ﬂƒ ¿ œ–ŒÿÀ¿ -
                if (nothing == false)
                {
                    if (reload == false)
                    {
                        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
                        {
                            OptionGun.bullet = OptionGun.bullet - 1;
                            playerCamera.TPSMinimumFOV = OptionCamera.recoilScoup;

                            shotAudio.PlayOneShot(ui.shotClip);
                            nextTimeToFire = Time.time + 1f / OptionGun.fireRate;
                            Shoot();
                        }
                        if (Input.GetMouseButtonDown(0))
                        {
                            playerCamera.TPSMinimumFOV = OptionCamera.recoilScoup;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            playerCamera.TPSMinimumFOV = OptionCamera.zoomScoup;
                        }
                    }
                }


            }
        }
            

        // - ƒŒ–¿¡Œ¿“‹ ›‘‘≈ “ ”— Œ–≈Õ»ﬂ ¿¬“ŒÃŒ¡»Àﬂ -

        if (Input.GetKey(KeyCode.F))
        {
            ParticalAll.nitro1.Play();
            ParticalAll.nitro2.Play();
        }

        // - Œ“ƒ¿≈“ DAMAGE - —Œ’–¿Õ≈Õ»≈ -

        PlayerPrefs.SetFloat("damage_gun", damage_gun);
    }
   


    // - œ–Œ¬≈– ¿ Õ¿ œŒœ¿ƒ¿Õ»≈ ¬ œ–Œ“»¬Õ» ¿ ------------------------------------* SHOOT() *--------------------------------------------
    void Shoot()
    {
        //anim_Gun.Play();// - ¿Õ»Ã¿÷»ﬂ œ”ÿ » - Œ“ƒ¿◊¿ -

        ParticalAll.anim_Part.Play(); // - ¬€À≈“¿≈“ œ”Àﬂ -

        ParticalAll.muzzleFlash.Play(); // - ›‘‘≈ “ ¬€—“–≈À¿ -
        
        if (Physics.Raycast(Gun_Camera.transform.position, Gun_Camera.transform.forward, out RaycastHit hit_gun, range_gun = 100f))
        {

            if (PlayerPrefs.HasKey("damage_gun_sale"))
            {
               damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
            }
            Debug.Log(hit_gun.transform.name);
           
            

            if (hit_gun.transform.TryGetComponent<MainZombieScript>(out var MainZombieScript))
            {
                // - ¬Œ«¬–¿Ÿ¿≈“ DAMAGE   œ–Œ“»¬Õ» ” -
                MainZombieScript.TakeDamage_gun(damage_gun);
            }
            if (hit_gun.transform.TryGetComponent<HitBox>(out var hitBox))
            {
                // - ¬Œ«¬–¿Ÿ¿≈“ DAMAGE   œ–Œ“»¬Õ» ” -
                hitBox.OnRaycastHit(this, ray.direction);
            }
            if (hit_gun.rigidbody != null)
            {
                // - —»À¿ œ¿“–ŒÕ¿   Œ¡‹≈ “¿Ã -
                hit_gun.rigidbody.AddForce(-hit_gun.normal * OptionGun.Last_TargetForce);
            }
            if (ui.prefabLastTarget != null)
            {
                // - œŒ—À≈ƒÕ»≈ œŒœ¿ƒ¿Õ»≈ - ›‘‘≈ “ -
                Last_TargetGO = Instantiate(ui.prefabLastTarget, hit_gun.point, Quaternion.LookRotation(hit_gun.normal));
            }

            Destroy(Last_TargetGO.gameObject, 0.1f);
        }

    }

    // - ƒ›‘ŒÀ“Õ€≈ Õ¿—“–Œ… »  ¿Ã≈–€ ----------------------------------------------------------*MODeDEFAULT*---------------------------------------- 
    public void ModedeDefault()
    {
        OptionCamera.zoom = 40;
        OptionCamera.distans = 6;

        OptionCamera.zoomScoup = 20;
        OptionCamera.distansScoup = 1f;

        OptionCamera.height = 0.94f;

        ui.sliderSensitivityScoup.value = OptionCamera.sensitivityScope;
        ui.sliderSensitivity.value = OptionCamera.sensitivity;
        playerCamera.TPSHeight = OptionCamera.height;
    }

    // - Õ¿—“–Œ… »  ¿Ã≈–€ - Œ–”∆»≈ -----------------------------------------------------------*MODeOPEnGUN*-------------------------------- 
    public void ModeOpenGun()
    {
        playerCamera.minOrbitY = OptionCamera.minOrbitY;
        playerCamera.maxOrbitY = OptionCamera.maxOrbitY;

        playerCamera.orbitYSpeed = OptionCamera.sensitivity;
        playerCamera.orbitXSpeed = OptionCamera.sensitivity;

        playerCamera.TPSMinimumFOV = OptionCamera.zoom;
        playerCamera.TPSDistance = OptionCamera.distans;
    }

    // - Õ¿—“–Œ… »  ¿Ã≈–€ - œ–»÷≈À -----------------------------------------------------------*MODeOPEnSCOPE*-------------------------------------------- 
    public void ModeOpenScope()
    {
        playerCamera.minOrbitY = OptionCamera.minOrbitYScoup;
        playerCamera.maxOrbitY = OptionCamera.maxOrbitYScoup;

        playerCamera.orbitYSpeed = OptionCamera.sensitivityScope;
        playerCamera.orbitXSpeed = OptionCamera.sensitivityScope;
        
        playerCamera.TPSMinimumFOV = OptionCamera.zoomScoup;
        playerCamera.TPSDistance = OptionCamera.distansScoup;        
    }
    
    // - Õ¿—“–Œ… » ◊”¬—“¬»“≈À‹ÕŒ—“» ¬ »√–≈ ------------------------------------------------*SLIDErSENSITIVITySCOUP*--------------------
    public void SliderSensitivityScoup()
    {
        OptionCamera.sensitivityScope = ui.sliderSensitivityScoup.value;
    }
    public void SliderSensitivity()
    {
        OptionCamera.sensitivity = ui.sliderSensitivity.value;
    }

    // - END ----------------------------------------------------------------------------------------------------------------------------
}
