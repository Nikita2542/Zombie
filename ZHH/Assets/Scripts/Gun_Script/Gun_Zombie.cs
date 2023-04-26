using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class Gun_Zombie : MonoBehaviour
{
    public bool openGun;
    public bool openScope;

    public Slider sliderSensitivityScoup;
    public Slider sliderSensitivity;

    public AudioSource shotAudio;
    public AudioClip shotClip;
    
 // - Настройка оружия-------------------------------------------------
    
    public RCC_Camera playerCamera;
  
    [Range(1, 5)]
    private float sensitivity = 1;
    [Range(1, 20)]
    public float sensitivityScope = 1;
    [Range(40, 120)]
    public float recoil;
    [Range(20, 60)]
    public float recoilScoup;
    [Range(20, 40)]
    public float zoom;
    [Range(20, 40)]
    public float zoomScoup;
    [Range(0, 7)]
    public float distans;
    [Range(0, 7)]
    public float distansScoup;
    private float height;

    // -------------------------------------------------------------------

    [Range (0, 30)]
    public int damage_gun = 20;   
    private float range_gun;
    [Range(0, 30)]
    public float fireRate = 50f;
    [Range(0, 30)]
    public float Last_TargetForce = 40;
    public Camera Gun_Camera;
    public ParticleSystem muzzleFlash;
    public GameObject Last_Target;
    public GameObject Last_TargetGO;
    public float nextTimeToFire = 0f;

    public Animation anim_Gun;
    public Animation anim_Part;

    public ParticleSystem nitro1;
    public ParticleSystem nitro2;

    public void Start()
    {
        openGun = true;
        openScope = false;
        ModedeDefault();

        if (PlayerPrefs.HasKey("damage_gun_sale"))
        {
            
            damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            openScope = true;
            openGun = false;
        }
        else
        {
            openGun = true;
            openScope = false;
        }

        if (openGun == true)
        {
            SliderSensitivity();
            ModeOpenGun();

            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                playerCamera.TPSMinimumFOV = recoil;

                shotAudio.PlayOneShot(shotClip);
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            if (Input.GetMouseButtonDown(0))
            {
                playerCamera.TPSMinimumFOV = recoil;
            }
            if (Input.GetMouseButtonUp(0))
            {
                playerCamera.TPSMinimumFOV = zoom;
            }

        }

        if(openScope == true)
        {
            playerCamera.TPSHeight = height;
            SliderSensitivityScoup();
            ModeOpenScope();

            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                playerCamera.TPSMinimumFOV = recoilScoup;

                shotAudio.PlayOneShot(shotClip);
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            if (Input.GetMouseButtonDown(0))
            {
                playerCamera.TPSMinimumFOV = recoilScoup;
            }
            if (Input.GetMouseButtonUp(0))
            {
                playerCamera.TPSMinimumFOV = zoomScoup;
            }
        }
       
        if (Input.GetKey(KeyCode.F))
        {
            nitro1.Play();
            nitro2.Play();
        }
        PlayerPrefs.SetInt("damage_gun", damage_gun);
    }
    public void ModedeDefault()
    {
        zoom = 40;
        distans = 6;

        zoomScoup = 20;
        distansScoup = 1f;

        height = 1.08f;

        sliderSensitivityScoup.value = sensitivityScope;
        sliderSensitivity.value = sensitivity;
        playerCamera.TPSHeight = height;
    }
    public void ModeOpenGun()
    {
        playerCamera.minOrbitY = -15f;
        playerCamera.maxOrbitY = 70f;

        playerCamera.orbitYSpeed = sensitivity;
        playerCamera.orbitXSpeed = sensitivity;

        playerCamera.TPSMinimumFOV = zoom;
        playerCamera.TPSDistance = distans;
    }
    public void ModeOpenScope()
    {
        playerCamera.minOrbitY = -5f;
        playerCamera.maxOrbitY = 1.5f;

        playerCamera.orbitYSpeed = sensitivityScope;
        playerCamera.orbitXSpeed = sensitivityScope;
        
        playerCamera.TPSMinimumFOV = zoomScoup;
        playerCamera.TPSDistance = distansScoup;        
    }
    
   
    public void SliderSensitivityScoup()
    {
        sensitivityScope = sliderSensitivityScoup.value;
    }
    public void SliderSensitivity()
    {
        sensitivity = sliderSensitivity.value;
    }
    void Shoot()
    {
        anim_Gun.Play();
        anim_Part.Play();
        muzzleFlash.Play();
        if (Physics.Raycast(Gun_Camera.transform.position, Gun_Camera.transform.forward, out RaycastHit hit_gun, range_gun = 100f))
        {
            
            if (PlayerPrefs.HasKey("damage_gun_sale"))
            {
                damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
            }
            Debug.Log(hit_gun.transform.name);
            if (hit_gun.transform.TryGetComponent<MainZombieScript>(out var MainZombieScript))
            {
                MainZombieScript.TakeDamage_gun(damage_gun);
            }
            if (hit_gun.transform.TryGetComponent<ZombEnemyGreen>(out var zombie_en))
            {
                zombie_en.TakeDamage_gun(damage_gun);
            }
            if(hit_gun.rigidbody != null)
            {
                hit_gun.rigidbody.AddForce(-hit_gun.normal * Last_TargetForce);
            }
            if(Last_Target != null)
            {
                Last_TargetGO = Instantiate(Last_Target, hit_gun.point, Quaternion.LookRotation(hit_gun.normal));
            }
            
            
        }
        Destroy(Last_TargetGO.gameObject, 0.1f);
    }
}
