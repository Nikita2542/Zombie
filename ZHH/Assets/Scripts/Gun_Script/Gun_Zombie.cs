using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Zombie : MonoBehaviour
{
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
    private float nextTimeToFire = 0f;

    public Animation anim_Gun;
    public Animation anim_Part;

    public ParticleSystem nitro1;
    public ParticleSystem nitro2;

    public void Start()
    {
        if (PlayerPrefs.HasKey("damage_gun_sale"))
        {
            
            damage_gun = PlayerPrefs.GetInt("damage_gun_sale");
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            nitro1.Play();
            nitro2.Play();
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
        PlayerPrefs.SetInt("damage_gun", damage_gun);
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
            GameObject Last_TargetGO = Instantiate(Last_Target, hit_gun.point, Quaternion.LookRotation(hit_gun.normal));
            Destroy(Last_TargetGO, 0.1f);
        }
    }
}
