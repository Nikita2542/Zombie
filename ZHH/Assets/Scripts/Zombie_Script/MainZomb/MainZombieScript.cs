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
    public Image killImage;
    private float killSec;

    public AudioSource hitAudio;
    public AudioClip hitClip;
    public bool boolAudio;
    public float secHit;
   

    public VisualEffect bloodVisual;

    public GameObject ZombieEmpty;
    // ----------------------------------------------------------------------
    public Animator animator;

    public float healthZombie = 100f;
    private float secund;
    private float secundDead;
    private float second;

    

    public GameObject slizPrefab;
    public GameObject targetGun;
    public GameObject MainZombie;
    public GameObject YakuZombie;
    public GameObject slizClone;
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
        killImage.gameObject.SetActive(false);
        bloodVisual.GetComponent<VisualEffect>().enabled = true;

        slizatorActiv = 0;
        healthZombie = 100f;

        RigActivity = false;
        mainCar = false;
        mainGun = false;
    }
    
    void Update()
    {
       // - �������������� � ������� -----------------------------------------
        if (mainCar == true)
        {
            //if (PlayerPrefs.HasKey("speedCAR"))
            //{
            //    speedCAR = PlayerPrefs.GetFloat("speedCAR");
            //}
            //if(speedCAR <= 40)
            //{
                
            //    // - ����� ������� �� ������
            //    JumpAttack();

            //}
            //if(speedCAR >= 40)
            //{             
                if (RigActivity == true)
                {
                    // - ����� ��������� �������� 
                    MakePhysical();
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
        // - �������������� � ������� -----------------------------------------
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

                
                MakePhysical();
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
        
        if (healthZombie <= 0)
        {
            
            if (MainZombie.CompareTag("Zombie_yellow"))
            {
                
                KnopkaR = 1;
                PlayerPrefs.SetInt("KnopkaR", KnopkaR);

                slizClone = Instantiate(slizPrefab, YakuZombie.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                MainZombie.GetComponent<BoxCollider>().enabled = false;

                RigActivity = true;
            }
        }
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

    public void MakePhysical()
    {
        animator.enabled = false;

        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = false;
        }
    }

    
    

    public void MakePhysicalUp()
    {
        Hips.transform.SetParent(Armature.transform);
        
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
