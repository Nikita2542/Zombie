using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiRun : MonoBehaviour
{
    [SerializeField] public int Player_Health = 100;
    [SerializeField] public GameObject player_Target;
    [SerializeField] public GameObject homee;
    [SerializeField] public Animator zomb_animation;
    [SerializeField] public Camera Enemy_Camera;
    
    private float run_enem = 0;
    private float SpeedLookRoot = 2;    
    private int collPlayer = 0;       
    private int range_enem = 100;

    
    private float secundomer;

    private int StartSecundomer;
    private float SecundomerTime;

    public void Start()
    {
        Player_Health = 100;
        PlayerPrefs.SetInt("PlayerHealth", Player_Health);
    }
    public void Update()
    {
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            Player_Health = PlayerPrefs.GetInt("PlayerHealth");
        }
        if (transform.position == homee.transform.position)
        {
            zomb_animation.SetInteger("Run", 4);          
            secundomer = 0;
        }
        if (secundomer >= 10)
        {           
            collPlayer = 0;
            secundomer = 10;
        }
        if (collPlayer == 0)
        {          
            zomb_animation.SetInteger("Attack", 2);
            transform.position = Vector3.MoveTowards(transform.position, homee.transform.position, Time.deltaTime * run_enem);
            Vector3 direction = (homee.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * SpeedLookRoot);
        }

        if (collPlayer == 1)
        {
            if (secundomer < 10) secundomer += Time.deltaTime;           
            transform.position = Vector3.MoveTowards(transform.position, player_Target.transform.position, Time.deltaTime * run_enem);
            Vector3 direction = (player_Target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * SpeedLookRoot);
        }
        if(StartSecundomer == 1)
        {
            if (SecundomerTime < 0.6f) SecundomerTime += Time.deltaTime;          
        }
        if(StartSecundomer == 0)
        {
            SecundomerTime = 0;
        }
        if(SecundomerTime >= 0.6f)
        {
            SecundomerTime = 0;
            Player_Health -= 5;
            PlayerPrefs.SetInt("PlayerHealth", Player_Health);
        }
        
        Enemy_RayCast();
    }

    public void Enemy_RayCast()
    {
        if (Physics.Raycast(Enemy_Camera.transform.position, Enemy_Camera.transform.forward, out _, range_enem = 30))
        {
            collPlayer = 1;
            run_enem = 10;           
            zomb_animation.SetInteger("Run", 3);                    
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {       
            if (other.gameObject.CompareTag("Player"))
            {
                
                run_enem = 1;
                zomb_animation.SetInteger("Attack", 1);
                range_enem = 0;
                StartSecundomer = 1;

                
                

            }              
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartSecundomer = 0;
            if (secundomer < 10)
            {               
                zomb_animation.SetInteger("Attack", 2);
                run_enem = 10;
                collPlayer = 1;
                range_enem = 100;
            }
            if (secundomer >= 10)
            {
                collPlayer = 0;
                run_enem = 10;
            }
        }
    }
   
}
