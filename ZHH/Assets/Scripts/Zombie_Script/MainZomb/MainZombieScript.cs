using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class MainZombieScript : MonoBehaviour
{
    //public GameObject clingsRight;
    //public GameObject handRight;
    //public float speedCAR;
    //public bool jump;

    
    public GunOptionsMain GunOptions;

    SkinnedMeshRenderer skinnedMeshRenderer;
    public float dieForce;
    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;

    public Image killImage;
    private float killSec;

    public Vector3 directionOn;

    public AudioSource hitAudio;
    public AudioClip hitClip;
    public bool boolAudio;
    public float secHit;
   

    public VisualEffect bloodVisual;
    UIHealthBar healthBar;

    public GameObject ZombieEmpty;
    // ----------------------------------------------------------------------
    Animator animator;

    public float healthZombie;
    public float maxHealth;
    private float secund;
    private float secundDead;
    private float second;

    

    public GameObject slizPrefab;
    public GameObject targetGun;
    private GameObject MainZombie;
    public GameObject YakuZombie;
    private GameObject slizClone;
    public GameObject Hips;
    public GameObject Armature;

    private bool hitGunActiv;
    public bool RigActivity;

    public bool mainCar;
    public bool mainGun;

    private int slizYellow;
    private int slizPickup;
    private int slizSpeed = 30;   
    public int slizatorActiv;
    private int KnopkaR;

    public Rigidbody[] ZombRigitAll;
 
    void Start()
    {
        
        
        MainZombie = this.gameObject;
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        killImage.gameObject.SetActive(false);
        bloodVisual.GetComponent<VisualEffect>().enabled = false;

        
        maxHealth = 100f;
        healthZombie = maxHealth;

        RigActivity = false;
        mainCar = false;
        mainGun = false;
    }
    
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;
       // - Взаимодействие с машиной -----------------------------------------
        if (mainCar == true)
        {
            //if (PlayerPrefs.HasKey("speedCAR"))
            //{
            //    speedCAR = PlayerPrefs.GetFloat("speedCAR");
            //}
            //if(speedCAR <= 40)
            //{
                
            //    // - Метод прыгает на машину
            //    JumpAttack();

            //}
            //if(speedCAR >= 40)
            //{             
                if (RigActivity == true)
                {
                    // - Метод отключает анимацию 
                    MakePhysical(directionOn);
                    if (second < 5)
                    {
                        Hips.transform.parent = null;
                        transform.position = Hips.transform.position;
                        ZombieEmpty.transform.position = Hips.transform.position;
                        second += Time.deltaTime;
                    }
                }
            //}
            
            
        }
        //if (jump == true)
        //{
        //    JumpAttackNo();
        //}
        if (second >= 5)
        {
            
            if (healthZombie > 0)
            {
                MakePhysicalUp();
            }
        }
        // - Взаимодействие с Оружием -----------------------------------------
        if (mainGun == true)
        {
            if (boolAudio == true)
            {
                if (secHit <= 0.2)
                {
                    secHit += Time.deltaTime;
                }
                if (secHit >= 0.2)
                {
                    hitAudio.PlayOneShot(hitClip);
                    boolAudio = false;
                    secHit = 0;

                }
            }
            if (PlayerPrefs.HasKey("slizator_true"))
            {
                slizatorActiv = PlayerPrefs.GetInt("slizator_true");
            }
            if (PlayerPrefs.HasKey("sliz_yellow"))
            {
                slizYellow = PlayerPrefs.GetInt("sliz_yellow");
            }
            if (slizatorActiv == 1)
            {
                if (Input.GetMouseButton(1))
                {
                    if (slizClone)
                    {

                        Sslizator();
                    }
                    
                    
                }
                PlayerPrefs.SetInt("slizator_true", slizatorActiv);
            }
            if (RigActivity == true)
            {
                if(killSec <= 1)
                {
                    killImage.gameObject.SetActive(true);
                    killSec += Time.deltaTime;
                }
                if(killSec >= 1)
                {
                    killImage.gameObject.SetActive(false);
                    
                }

                
                MakePhysical(directionOn);
                if (slizPickup == 1)
                {
                    if (secundDead < 10)
                    {         
                        secundDead += Time.deltaTime;
                    }
                    if (secundDead >= 10)
                    {
                        RigActivity = false;
                        secundDead = 0;
                        Die();
                    }
                }
            }

            if (hitGunActiv == true)
            {
                
                if (secund <= 0.7)
                {
                    
                    secund += Time.deltaTime;
                }
                HitGun();
                
                if (secund >= 0.7)
                {
                    
                    bloodVisual.GetComponent<VisualEffect>().enabled = false;
                    secund = 0;
                    hitGunActiv = false;
                }
                return;
            }

            if (hitGunActiv == false)
            {
                HitGunFalse();
                return;
            }
            
        }    
    }

    public void TakeDamage_gun(float amount)
    {
        healthZombie -= amount;      
        healthBar.SetHealthBarPercentage(healthZombie / maxHealth);
        if (healthZombie <= 0)
        {
            killSec = 0;
            if (MainZombie.CompareTag("Zombie_yellow"))
            {
                
                KnopkaR = 1;
                PlayerPrefs.SetInt("KnopkaR", KnopkaR);

                slizClone = Instantiate(slizPrefab, YakuZombie.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                MainZombie.GetComponent<BoxCollider>().enabled = false;

                RigActivity = true;
            }
        }
        blinkTimer = blinkDuration;
        
    }

    public void ApplyForce(Vector3 force)
    {
        var rigidBody = animator.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
        rigidBody.AddForce(force, ForceMode.VelocityChange);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCar = true;          
            RigActivity = true;          
        }
        if (other.gameObject.tag == "Last")
        {
            boolAudio = true;
            bloodVisual.GetComponent<VisualEffect>().enabled = true;
            mainGun = true;
            hitGunActiv = true;
            return;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Last")
        {
            hitGunActiv = false;
            return;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < ZombRigitAll.Length; i++)
        {
            ZombRigitAll[i].isKinematic = true;
        }
    }

    public void MakePhysical(Vector3 directionOn)
    {
        directionOn.y = 1;
        ApplyForce(directionOn * dieForce);
        animator.enabled = false;
        healthBar.gameObject.SetActive(false);

        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = false;
        }

    }

    
    

    public void MakePhysicalUp()
    {
        Hips.transform.SetParent(Armature.transform);
        healthBar.gameObject.SetActive(true);
        animator.enabled = true;
        animator.SetTrigger("Idle");
        animator.SetInteger("Stand", 1);
        
        RigActivity = false;
        second = 0;

        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = true;
        }
        gameObject.transform.position = new Vector3(ZombieEmpty.transform.position.x, 0, transform.position.z);
    }

    public void Sslizator()
    {
        slizClone.transform.position = Vector3.MoveTowards(slizClone.transform.position, targetGun.transform.position, Time.deltaTime * slizSpeed);
        Vector3 direction = (targetGun.transform.position - slizClone.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        slizClone.transform.rotation = Quaternion.Lerp(slizClone.transform.rotation, lookRotation, Time.deltaTime * slizSpeed);

        if (slizClone.transform.position == targetGun.transform.position)
        {
            slizYellow++;
            slizPickup++;
            PlayerPrefs.SetInt("sliz_yellow", slizYellow);
            Die_Slizz();

            PlayerPrefs.Save();
        }
    }

    void Die_Slizz()
    {
        Destroy(slizClone);
       
    }
    void Die()
    {
        killSec = 0;
        Destroy(MainZombie.gameObject);
    }

    public void HitGun()
    {
        animator.SetInteger("HitGun", 1);
        
    }

    public void HitGunFalse()
    {
        animator.SetInteger("HitGun", 2);
    }
    //public void JumpAttack()
    //{
        
    //    animator.SetTrigger("JumpAttack");
    //}
    //public void JumpAttackNo()
    //{
        
    //    animator.SetTrigger("JumpNo");
    //}
}
