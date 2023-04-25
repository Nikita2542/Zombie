using DistantLands.Cozy;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class InverstZombiKinemstik : MonoBehaviour
{
    public float health_zomb;
    public Animator animatorZomb;
    public Rigidbody[] ZombRigitAll;
    public GameObject Hips;
    public GameObject Armature;
   
    public bool RigActivity;
    private float second;
    

    public void Start()
    {

        

        RigActivity = false;
        PlayerPrefs.SetInt("deadActiv", RigActivity ? 1 : 0);

    }
    private void Awake()
    {
        for(int i = 0; i < ZombRigitAll.Length; i++)
        {
            ZombRigitAll[i].isKinematic = true;
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("health_zomb"))
        {
            health_zomb = PlayerPrefs.GetFloat("health_zomb");
        }

        if (PlayerPrefs.HasKey("deadActiv"))
        {
            RigActivity = PlayerPrefs.GetInt("deadActiv") == 1 ? true : false;
        }
        if(Input.GetKey(KeyCode.H))
        {
            animatorZomb.enabled = false;
            Hips.transform.parent = null;
            Hips.transform.position = transform.position;
            return;
            
        }

        if (RigActivity == true)
        {
            
            MakePhysical();
            if (second < 5)
            {
                Hips.transform.parent = null;
                transform.position = Hips.transform.position;
                second += Time.deltaTime;
            }
            
        }
        
        if (second >= 5)
        {
            
            if (health_zomb > 0)
            {
                MakePhysicalUp();
            }            
        }
    }

    public void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.CompareTag("Player"))
        {            
            RigActivity = true;
            PlayerPrefs.SetInt("deadActiv", RigActivity ? 1 : 0);
            return;
        }       
    }

    public void MakePhysical()
    {      
        animatorZomb.enabled = false;
        
        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = false;
        }
    }

    public void MakePhysicalUp()
    {
        Hips.transform.SetParent(Armature.transform);
        
        animatorZomb.enabled = true;
        animatorZomb.SetTrigger("Idle");
        animatorZomb.SetInteger("Stand", 1);
        gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);

       
        second = 0;
            
       

        for (int i = 0; i < ZombRigitAll.Length; ++i)
        {
            ZombRigitAll[i].isKinematic = true;
        }
    }
   
}
