using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieEnemi : MonoBehaviour
{
    public Animator animator;
    public float health_zomb = 100f;  
    private float secund;
    public float secundDead;

    private int KnopkaR;
 
    public GameObject Sliz_Yellow;  
    public GameObject target;  
    public GameObject Zomb_yellow;
    public GameObject Armature;
    public GameObject Sliz_Yellow_Go;

    public bool deadActiv;
    private bool hitGunActiv;
    

    private int speed_sliz = 30;
    public int sliz_yellow;       
    private int slizator_true;

    public void Start()
    {       
        slizator_true = 0;
        PlayerPrefs.SetInt("slizator_true", slizator_true);
        health_zomb = 100f;
    }
    public void TakeDamage_gun(float amount)
    {
        health_zomb -= amount;
        PlayerPrefs.SetFloat("health_zomb", health_zomb);
        if (health_zomb <= 0)
        {              
            if (Zomb_yellow.CompareTag("Zombie_yellow"))
            {
                KnopkaR = 1;
                PlayerPrefs.SetInt("KnopkaR", KnopkaR);
               
                Sliz_Yellow_Go = Instantiate(Sliz_Yellow, Armature.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                Zomb_yellow.GetComponent<BoxCollider>().enabled = false;

                deadActiv = true;
                PlayerPrefs.SetInt("deadActiv", deadActiv ? 1 : 0);
            }               
        }       
    }
   
    public void Update()
    {              
        if (PlayerPrefs.HasKey("deadActiv"))
        {
            deadActiv = PlayerPrefs.GetInt("deadActiv") == 1 ? true : false;
        }
        
        if (PlayerPrefs.HasKey("slizator_true"))
        {
            slizator_true = PlayerPrefs.GetInt("slizator_true");          
        }
        if(deadActiv == true)
        {
            if(sliz_yellow == 1)
            {
                if (secundDead < 10)
                {
                    secundDead += Time.deltaTime;
                }
                if (secundDead >= 10)
                {

                    deadActiv = false;
                    secundDead = 0;
                    Die();

                }
            }           
        }
        if (slizator_true == 1)
        {
            if (Input.GetMouseButton(1))
            {
                Sslizator();            
            }
        } 
        if(hitGunActiv == true)
        {
            if(secund <= 0.5)
            {
                secund += Time.deltaTime;
            }
            HitGun();
            if(secund >= 0.5)
            {               
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

    public void Sslizator()
    {       
        Sliz_Yellow_Go.transform.position = Vector3.MoveTowards(Sliz_Yellow_Go.transform.position, target.transform.position, Time.deltaTime * speed_sliz);
        Vector3 direction = (target.transform.position - Sliz_Yellow_Go.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Sliz_Yellow_Go.transform.rotation = Quaternion.Lerp(Sliz_Yellow_Go.transform.rotation, lookRotation, Time.deltaTime * speed_sliz);
        if (Sliz_Yellow_Go.transform.position == target.transform.position)
        {               
            sliz_yellow++;
            PlayerPrefs.SetInt("sliz_yellow", sliz_yellow);
            Die_Slizz();
                
            PlayerPrefs.Save();          
        }
    }

    void Die_Slizz()
    {
        Destroy(Sliz_Yellow_Go);
    }
    void Die()
    {
        Destroy(Zomb_yellow.gameObject);
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Last")
        {
            hitGunActiv = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Last")
        {
            hitGunActiv = false;
        }
    }
    public void HitGun()
    {
        animator.SetInteger("HitGun", 1);
    }
    public void HitGunFalse()
    {
        animator.SetInteger("HitGun", 2);
    }
}
