using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.VFX;

public class MainZombieScript : MonoBehaviour
{

    public float healthZombie;
    public GunOptionsMain GunOptions;

    UIHealthBar healthBar;

    //- ��������� ������� �������� --------------------------------------------------------/

    public GameOption gameOption;
    [System.Serializable]
    public class GameOption
    {
        public GameObject ZombieEmpty;
        public GameObject slizPrefab;
        public GameObject targetGun;
        public GameObject YakuZombie;
        public GameObject Hips;
        public GameObject Armature;


    }

    private GameObject MainZombie;
    private GameObject slizClone;

    //- ��������� �������� ----------------------------------------------------------------/

    public ObjectScene objectScene;
    [System.Serializable]
    public class ObjectScene
    {
        public Image killImage;
        public AudioSource hitAudio;
        public AudioClip hitClip;
        public VisualEffect bloodVisual;
    }

    Animator animator;

    //- ��������� ����� -------------------------------------------------------------------/

    public OptionBlink optionBlink;
    [System.Serializable]
    public class OptionBlink
    {

        public float blinkIntensity;
        public float blinkDuration;
        public float blinkTimer;

    }

    SkinnedMeshRenderer skinnedMeshRenderer;

    //- ������ ������� -------------------------------------------------------------------/

    private int slizYellow;
    private int slizPickup;
    private int slizSpeed = 30;
    private int KnopkaR;

    private int slizatorActiv;


    private bool hitGunActiv;
    private bool boolAudio;
    private bool RigActivity;
    private bool mainCar;
    private bool mainGun;


    private float killSec;
    private float secund;
    private float secundDead;
    private float second;
    private float secHit;
    private float maxHealth;

    //- ����� ���� ����� -----------------------------------------------------------------/

    public Rigidbody[] ZombRigitAll;



    //- START -------------------------------------------------------------------------------------------------------------/
    void Start()
    {
        
        
        MainZombie = this.gameObject;
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        objectScene.killImage.gameObject.SetActive(false);
        objectScene.bloodVisual.GetComponent<VisualEffect>().enabled = false;

        
        maxHealth = 100f;
        healthZombie = maxHealth;

        RigActivity = false;
        mainCar = false;
        mainGun = false;
    }
    
    
    //- UPDATE ------------------------------------------------------------------------------------------------------------/
    void Update()
    {
        ScinBlink();

        // - �������������� � ������� -

        if (mainCar == true)
        {
            if (RigActivity == true)
            {
                // - ����� ��������� �������� -
                MakePhysical();
                if (second < 5)
                {
                    gameOption.Hips.transform.parent = null;
                    transform.position = gameOption.Hips.transform.position;
                    gameOption.ZombieEmpty.transform.position = gameOption.Hips.transform.position;
                    second += Time.deltaTime;
                }
            }
        }        
        if (second >= 5)
        {
            
            if (healthZombie > 0)
            {
                MakePhysicalUp();
            }
        }

        // - �������������� � ������� -

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
                    objectScene.hitAudio.PlayOneShot(objectScene.hitClip);
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
                    objectScene.killImage.gameObject.SetActive(true);
                    killSec += Time.deltaTime;
                }
                if(killSec >= 1)
                {
                    objectScene.killImage.gameObject.SetActive(false);
                    
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

                    objectScene.bloodVisual.GetComponent<VisualEffect>().enabled = false;
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



    // - ������� ���� --------------------------------------------------------------*TAKeDAMAGE_GUN*-----------------------/
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

                slizClone = Instantiate(gameOption.slizPrefab, gameOption.YakuZombie.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                MainZombie.GetComponent<BoxCollider>().enabled = false;

                RigActivity = true;
            }
        }
        optionBlink.blinkTimer = optionBlink.blinkDuration;
        
    }



    // - ��������� - �������� �� ����  ----------------------------------------------*OnTRIGErENTER*-----------------------/
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
            objectScene.bloodVisual.GetComponent<VisualEffect>().enabled = true;// true
            mainGun = true;
            hitGunActiv = true;
            return;
        }
    }
    // - ��������� - �������� �� �����  ----------------------------------------------*OnTRIGErEXIT*-----------------------/
    public void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Last")
        {
            hitGunActiv = false;
            return;
        }
    }



    // - ����� ���� - ���������� ---------------------------------------------------------*AWAKE*--------------------------/
    private void Awake()
    {
        for (int i = 0; i < ZombRigitAll.Length; i++)
        {
            ZombRigitAll[i].isKinematic = true;
        }
    }



    // - ��������� �� ����� ��������� - ���������� -------------------------------------*SCInBLINK*------------------------/
    public void ScinBlink()
    {
        optionBlink.blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(optionBlink.blinkTimer / optionBlink.blinkDuration);
        float intensity = (lerp * optionBlink.blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;
    }



    // - ��������� RAGDOL - ������� ����� ---------------------------------------------*MAKePHYSICAL*----------------------/
    public void MakePhysical()
    {
              
        animator.enabled = false;
        healthBar.gameObject.SetActive(false);

        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = false;
        }

    }
    // - ���������� RAGDOL - ����� ������ ---------------------------------------------*MAKePHYSICALUP*--------------------/
    public void MakePhysicalUp()
    {
        gameOption.Hips.transform.SetParent(gameOption.Armature.transform);
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
        gameObject.transform.position = new Vector3(gameOption.ZombieEmpty.transform.position.x, 0, transform.position.z);
    }



    // - ������ ����� -------------------------------------------------------------------*SSLIZATOR*-----------------------/
    public void Sslizator()
    {
        slizClone.transform.position = Vector3.MoveTowards(slizClone.transform.position, gameOption.targetGun.transform.position, Time.deltaTime * slizSpeed);
        Vector3 direction = (gameOption.targetGun.transform.position - slizClone.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        slizClone.transform.rotation = Quaternion.Lerp(slizClone.transform.rotation, lookRotation, Time.deltaTime * slizSpeed);

        if (slizClone.transform.position == gameOption.targetGun.transform.position)
        {
            slizYellow++;
            slizPickup++;
            PlayerPrefs.SetInt("sliz_yellow", slizYellow);
            Die_Slizz();

            PlayerPrefs.Save();
        }
    }



    // - ����������� ����� --------------------------------------------------------------*DIE_SLIZZ*-----------------------/
    void Die_Slizz()
    {
        Destroy(slizClone);    
    }
    // - ����������� ����� -----------------------------------------------------------------*DIE*--------------------------/
    void Die()
    {
        killSec = 0;
        Destroy(MainZombie.gameObject);
    }



    // - �������� - ��������� � ����� - ������ --------------------------------------------*HItGUN*------------------------/
    public void HitGun()
    {
        animator.SetInteger("HitGun", 1);
        
    }
    // - �������� - ��������� � ����� - ��������� ---------------------------------------*HItGUnFALSE*---------------------/
    public void HitGunFalse()
    {
        animator.SetInteger("HitGun", 2);
    }
}
