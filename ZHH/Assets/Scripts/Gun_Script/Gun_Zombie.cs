using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class Gun_Zombie : MonoBehaviour
{
    // - ��������� ������ --------------------------------------------------------------------------------------------------------------

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

        public bool openGun;
        public bool openScope;
    }

    

    public Animation anim_Part;

    public RCC_Camera playerCamera;
    public Camera Gun_Camera;

    // - ��������� ������ --------------------------------------------------------------------------------------------------------------

    public OptionAvtomat OptionGun;
    [System.Serializable]
    public class OptionAvtomat
    {
        [Range(0, 30)] public float damage_gun = 20;
        [Range(0, 30)] public float fireRate = 50f;
        [Range(0, 1000)] public float Last_TargetForce = 40;

        public int bullet;
        public int bulletMax;
        public int puliAll;
        public float reloading;

        public Slider sliderSensitivity;
        public Slider sliderSensitivityScoup;

        public Text textBullet;
        public Text textBulletMax;
    }
    private float secReload;
    private bool reload;
    private bool nothing;

    // - ������ ----------------------------------------------------------------------------------------------------------------------------------

    public particle ParticalAll;
    [System.Serializable]
    public class particle
    {
        public ParticleSystem muzzleFlash;
        public ParticleSystem nitro1;
        public ParticleSystem nitro2;
    }

    private AudioSource shotAudio;
    public AudioClip shotClip;

    public GameObject prefabLastTarget;
    private GameObject Last_TargetGO;

    private float nextTimeToFire = 0f;
    private float height;
    private float range_gun;
  
    private Vector3 directionOn;
    public Image imageReloading;

    // - START -------------------------------------------------------------------------------------------------------------------------
    public void Start()
    {
        imageReloading.fillAmount = 0;
        imageReloading.gameObject.SetActive(false);
        OptionGun.bullet = OptionGun.bulletMax;
        

        OptionCamera.openGun = true;
        OptionCamera.openScope = false;

        shotAudio = GetComponent<AudioSource>();

        // - ������ ��������� ��������� ������ -
        ModedeDefault();

        if (PlayerPrefs.HasKey("damage_gun_sale"))
        {
            OptionGun.damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
        }
    }
    // - UPDATE GO ---------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        OptionGun.textBulletMax.text = OptionGun.puliAll.ToString();
        if (OptionGun.puliAll <= 0)
        {
            if(OptionGun.bullet <= 0)
            {
                nothing = true;
            }
            
        }

        OptionGun.textBullet.text  = OptionGun.bullet.ToString();
        
        // - ����������� - ����������� ���� -
        if (OptionGun.bullet <= 0)
        {           
            
            
            reload = true;
            if (secReload <= OptionGun.reloading)
            {
                if (OptionGun.puliAll > 0)
                {
                    secReload += Time.deltaTime;
                    imageReloading.gameObject.SetActive(true);
                    if (imageReloading.fillAmount < 1)
                    {
                        imageReloading.fillAmount += Time.deltaTime / OptionGun.reloading;
                    }
                }
               
            }
            if(secReload >= OptionGun.reloading)
            {
               
                if (OptionGun.puliAll > 0)
                {
                    OptionGun.bullet = OptionGun.bulletMax;
                    OptionGun.puliAll -= OptionGun.bulletMax;
                    if (imageReloading.fillAmount >= 1)
                    {
                        imageReloading.fillAmount = 0;
                    }
                    imageReloading.gameObject.SetActive(false);
                }
                if(OptionGun.puliAll <= OptionGun.bulletMax)
                {
                    OptionGun.bulletMax = OptionGun.puliAll;
                }
                
               
                

                secReload = 0;
            }
        }
        else
        {
            reload = false;
        }
        
        // - �������� ��������� ������� -

        if (Input.GetMouseButton(1))
        {
            OptionCamera.openScope = true;
            OptionCamera.openGun = false;
        }
        else
        {
            OptionCamera.openGun = true;
            OptionCamera.openScope = false;
        }

        // - ������� ��������� -

        if (OptionCamera.openGun == true)
        {
            SliderSensitivity();
            ModeOpenGun();

            // - ����������� ������ -
            if (nothing == false)
            {
                if (reload == false)
                {
                    if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
                    {
                        OptionGun.bullet = OptionGun.bullet - 1;
                        playerCamera.TPSMinimumFOV = OptionCamera.recoil;

                        shotAudio.PlayOneShot(shotClip);
                        nextTimeToFire = Time.time + 1f / OptionGun.fireRate;
                        Shoot();
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        playerCamera.TPSMinimumFOV = OptionCamera.recoil;
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        playerCamera.TPSMinimumFOV = OptionCamera.zoom;
                    }
                }
            }
            
        }

        // - ������� ������� -

        if (OptionCamera.openScope == true)
        {
            playerCamera.TPSHeight = height;
            SliderSensitivityScoup();
            ModeOpenScope();

            // - ����������� ������ -
            if (nothing == false)
            {
                if (reload == false)
                {
                    if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
                    {
                        OptionGun.bullet = OptionGun.bullet - 1;
                        playerCamera.TPSMinimumFOV = OptionCamera.recoilScoup;

                        shotAudio.PlayOneShot(shotClip);
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

        // - ��������� ������ ��������� ���������� -

        if (Input.GetKey(KeyCode.F))
        {
            ParticalAll.nitro1.Play();
            ParticalAll.nitro2.Play();
        }

        // - ������ DAMAGE - ���������� -

        PlayerPrefs.SetFloat("damage_gun", OptionGun.damage_gun);
    }
   


    // - �������� �� ��������� � ���������� ------------------------------------* SHOOT() *--------------------------------------------
    void Shoot()
    {
        //anim_Gun.Play();// - �������� ����� - ������ -

        anim_Part.Play(); // - �������� ���� -

        ParticalAll.muzzleFlash.Play(); // - ������ �������� -
        
        if (Physics.Raycast(Gun_Camera.transform.position, Gun_Camera.transform.forward, out RaycastHit hit_gun, range_gun = 100f))
        {

            if (PlayerPrefs.HasKey("damage_gun_sale"))
            {
                OptionGun.damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
            }
            Debug.Log(hit_gun.transform.name);
           
            

            if (hit_gun.transform.TryGetComponent<MainZombieScript>(out var MainZombieScript))
            {
                // - ���������� DAMAGE � ���������� -
                MainZombieScript.TakeDamage_gun(OptionGun.damage_gun);
            }
            if (hit_gun.rigidbody != null)
            {
                // - ���� ������� � �������� -
                hit_gun.rigidbody.AddForce(-hit_gun.normal * OptionGun.Last_TargetForce);
            }
            if (prefabLastTarget != null)
            {
                // - ��������� ��������� - ������ -
                Last_TargetGO = Instantiate(prefabLastTarget, hit_gun.point, Quaternion.LookRotation(hit_gun.normal));
            }

            Destroy(Last_TargetGO.gameObject, 0.1f);
        }

    }

    // - ��������� ��������� ������ ----------------------------------------------------------*MODeDEFAULT*---------------------------------------- 
    public void ModedeDefault()
    {
        OptionCamera.zoom = 40;
        OptionCamera.distans = 6;

        OptionCamera.zoomScoup = 20;
        OptionCamera.distansScoup = 1f;

        height = 1.08f;

        OptionGun.sliderSensitivityScoup.value = OptionCamera.sensitivityScope;
        OptionGun.sliderSensitivity.value = OptionCamera.sensitivity;
        playerCamera.TPSHeight = height;
    }

    // - ��������� ������ - ������ -----------------------------------------------------------*MODeOPEnGUN*-------------------------------- 
    public void ModeOpenGun()
    {
        playerCamera.minOrbitY = -15f;
        playerCamera.maxOrbitY = 70f;

        playerCamera.orbitYSpeed = OptionCamera.sensitivity;
        playerCamera.orbitXSpeed = OptionCamera.sensitivity;

        playerCamera.TPSMinimumFOV = OptionCamera.zoom;
        playerCamera.TPSDistance = OptionCamera.distans;
    }

    // - ��������� ������ - ������ -----------------------------------------------------------*MODeOPEnSCOPE*-------------------------------------------- 
    public void ModeOpenScope()
    {
        playerCamera.minOrbitY = -5f;
        playerCamera.maxOrbitY = 1.5f;

        playerCamera.orbitYSpeed = OptionCamera.sensitivityScope;
        playerCamera.orbitXSpeed = OptionCamera.sensitivityScope;
        
        playerCamera.TPSMinimumFOV = OptionCamera.zoomScoup;
        playerCamera.TPSDistance = OptionCamera.distansScoup;        
    }
    
    // - ��������� ���������������� � ���� ------------------------------------------------*SLIDErSENSITIVITySCOUP*--------------------
    public void SliderSensitivityScoup()
    {
        OptionCamera.sensitivityScope = OptionGun.sliderSensitivityScoup.value;
    }
    public void SliderSensitivity()
    {
        OptionCamera.sensitivity = OptionGun.sliderSensitivity.value;
    }

    // - END ----------------------------------------------------------------------------------------------------------------------------
}
