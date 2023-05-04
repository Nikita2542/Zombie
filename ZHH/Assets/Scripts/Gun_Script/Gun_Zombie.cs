using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class Gun_Zombie : MonoBehaviour
{

    // - НАСТРОЙКА КАМЕРЫ --------------------------------------------------------------------------------------------------------------
    [Header("Урон оружия")]
    public float damage_gun = 20;
    [Header("Настройка камера")]
    public RCC_Camera playerCamera;

    public WeaponRecoil recoilGun;
    
    [HideInInspector]
    public Camera Gun_Camera;
    public OptionGunAvtomat OptionCamera;
    [System.Serializable]
    public class OptionGunAvtomat
    {
        [Header("Чувствительность")]
        [Range(1, 5)] public float sensitivity = 1;
        [Range(1, 20)] public float sensitivityScope = 1;
        [Header("Отдача при стрельбе")]
        [Range(40, 120)] public float recoil;
        [Range(20, 60)] public float recoilScoup;
        [Header("Зум камеры ⚠")]
        [Range(20, 40)] public float zoom;
        [Range(20, 40)] public float zoomScoup;
        [Header("Дистанция камеры ⚠")]
        [Range(0, 7)] public float distans;
        [Range(0, 2)] public float distansScoup;
        [Header("Высота камеры ⚠")]
        public float height;
        [Header("Вертикальная возможность")]
        public float minOrbitY;
        public float maxOrbitY;
        [Header("Вертикальная возможность в прицеле")]
        public float minOrbitYScoup;
        public float maxOrbitYScoup;
        [Header("Проверка выхода из прицела ⚠")]
        public bool openGun;
        public bool openScope;
    }







    // - НАСТРОЙКА ОРУЖИЯ --------------------------------------------------------------------------------------------------------------
    
    private GunOptionsMain gunOptionsMain;
    [Header("Настройка оружия")]
    public OptionAvtomat OptionGun;
    [System.Serializable]
    public class OptionAvtomat
    {
        
        [Range(0, 30)] [Header("Скорострельность")]public float fireRate = 50f;
        [Range(0, 1000)][Header("Сила патрона")] public float Last_TargetForce = 40;
        [Header("Патроны")]
        public int bullet;
        public int bulletMax;
        public int puliAll;
        [Header("Время перезарядки")]
        public float reloading;

        
        [HideInInspector] public float remNoScoup;
        [HideInInspector] public float remScoup;
    }
   
    Ray ray;
    private float secReload;
    
    private bool nothing;

    // - ДРУГОЕ ----------------------------------------------------------------------------------------------------------------------------------
    [Header("UI")]
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

    private void Awake()
    {
        recoilGun = GetComponent<WeaponRecoil>();
    }
    public void Start()
    {
        OptionGun.remNoScoup = 607;
        OptionGun.remScoup = 703;
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

        // - ЗАДАЕТ ДЭФОЛТНЫЕ НАСТРОЙКИ КАМЕРЫ -
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

        // - ПЕРЕЗАРЯДКА - ЗАКОНЧИЛИСЬ ПУЛИ -
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
        
        
        // - ПРОВЕРКА СОСТОЯНИЯ ПРИЦЕЛА -

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

        // - ПРИЦЕЛА НЕАКТИВЕН -
        if (gunOptionsMain.gunSlizator == false)
        {
            if (OptionCamera.openGun == true)
            {
                SliderSensitivity();
                ModeOpenGun();

                // - ПЕРЕЗАРЯДКА ПРОШЛА -

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
            

        // - ПРИЦЕЛА АКТИВЕН -
        if (gunOptionsMain.gunSlizator == false)
        {
            if (OptionCamera.openScope == true)
            {
                playerCamera.TPSHeight = OptionCamera.height;
                SliderSensitivityScoup();
                ModeOpenScope();

                // - ПЕРЕЗАРЯДКА ПРОШЛА -
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
            

        // - ДОРАБОАТЬ ЭФФЕКТ УСКОРЕНИЯ АВТОМОБИЛЯ -

        if (Input.GetKey(KeyCode.F))
        {
            ParticalAll.nitro1.Play();
            ParticalAll.nitro2.Play();
        }

        // - ОТДАЕТ DAMAGE - СОХРАНЕНИЕ -

        PlayerPrefs.SetFloat("damage_gun", damage_gun);
    }
   


    // - ПРОВЕРКА НА ПОПАДАНИЕ В ПРОТИВНИКА ------------------------------------* SHOOT() *--------------------------------------------
    void Shoot()
    {
        recoilGun.playerCamera = playerCamera;
        recoilGun.GenerateRecoil();
        //anim_Gun.Play();// - АНИМАЦИЯ ПУШКИ - ОТДАЧА -

        ParticalAll.anim_Part.Play(); // - ВЫЛЕТАЕТ ПУЛЯ -

        ParticalAll.muzzleFlash.Play(); // - ЭФФЕКТ ВЫСТРЕЛА -
        
        if (Physics.Raycast(Gun_Camera.transform.position, Gun_Camera.transform.forward, out RaycastHit hit_gun, range_gun = 100f))
        {

            if (PlayerPrefs.HasKey("damage_gun_sale"))
            {
               damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
            }
            Debug.Log(hit_gun.transform.name);
           
            

            if (hit_gun.transform.TryGetComponent<MainZombieScript>(out var MainZombieScript))
            {
                // - ВОЗВРАЩАЕТ DAMAGE К ПРОТИВНИКУ -
                MainZombieScript.TakeDamage_gun(damage_gun);
            }
            if (hit_gun.transform.TryGetComponent<HitBox>(out var hitBox))
            {
                // - ВОЗВРАЩАЕТ DAMAGE К ПРОТИВНИКУ -
                hitBox.OnRaycastHit(this, ray.direction);
            }
            if (hit_gun.rigidbody != null)
            {
                // - СИЛА ПАТРОНА К ОБЬЕКТАМ -
                hit_gun.rigidbody.AddForce(-hit_gun.normal * OptionGun.Last_TargetForce);
            }
            if (ui.prefabLastTarget != null)
            {
                // - ПОСЛЕДНИЕ ПОПАДАНИЕ - ЭФФЕКТ -
                Last_TargetGO = Instantiate(ui.prefabLastTarget, hit_gun.point, Quaternion.LookRotation(hit_gun.normal));
            }

            Destroy(Last_TargetGO.gameObject, 0.1f);
        }

    }

    // - ДЭФОЛТНЫЕ НАСТРОЙКИ КАМЕРЫ ----------------------------------------------------------*MODeDEFAULT*---------------------------------------- 
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

    // - НАСТРОЙКИ КАМЕРЫ - ОРУЖИЕ -----------------------------------------------------------*MODeOPEnGUN*-------------------------------- 
    public void ModeOpenGun()
    {
        playerCamera.minOrbitY = OptionCamera.minOrbitY;
        playerCamera.maxOrbitY = OptionCamera.maxOrbitY;

        playerCamera.orbitYSpeed = OptionCamera.sensitivity;
        playerCamera.orbitXSpeed = OptionCamera.sensitivity;

        playerCamera.TPSMinimumFOV = OptionCamera.zoom;
        playerCamera.TPSDistance = OptionCamera.distans;
    }

    // - НАСТРОЙКИ КАМЕРЫ - ПРИЦЕЛ -----------------------------------------------------------*MODeOPEnSCOPE*-------------------------------------------- 
    public void ModeOpenScope()
    {
        playerCamera.minOrbitY = OptionCamera.minOrbitYScoup;
        playerCamera.maxOrbitY = OptionCamera.maxOrbitYScoup;

        playerCamera.orbitYSpeed = OptionCamera.sensitivityScope;
        playerCamera.orbitXSpeed = OptionCamera.sensitivityScope;
        
        playerCamera.TPSMinimumFOV = OptionCamera.zoomScoup;
        playerCamera.TPSDistance = OptionCamera.distansScoup;        
    }
    
    // - НАСТРОЙКИ ЧУВСТВИТЕЛЬНОСТИ В ИГРЕ ------------------------------------------------*SLIDErSENSITIVITySCOUP*--------------------
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
