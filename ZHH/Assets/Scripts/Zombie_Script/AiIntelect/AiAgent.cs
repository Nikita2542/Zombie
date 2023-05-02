using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public PlayerHealth playerHealth; 

    public Speedometr speedometr;
    [HideInInspector]
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    [HideInInspector]
    public Ragdoll ragdoll;
    [HideInInspector]
    public HitBox[] hitBox;
    [HideInInspector]
    public SkinnedMeshRenderer mesh;
    [HideInInspector]
    public UIHealthBar ui;
    [HideInInspector]
    public Transform playerTransform;

    [HideInInspector]
    public Health health;

    public GameObject hips;
    public GameObject armature;
    public GameObject mainObject;

    [HideInInspector] public bool mainCar;
    public bool attackActiv;
    [HideInInspector] public float second;
    public float secondPlayer;
    public int damageEnemy;
    public Animator animator;
    public float damagePeriod;
    // Start is called before the first frame update
    void Start()
    {
        
        ragdoll = GetComponent<Ragdoll>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        hitBox = GetComponentsInChildren<HitBox>();
        health = GetComponent<Health>();

        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiStandState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCar == true)
        {
            
           
            second += Time.deltaTime;
        }

        if (attackActiv == true)
        {
            if(playerHealth.playerHealth > 0)
            {
                if (secondPlayer < damagePeriod)
                {
                    animator.SetBool("Attack", true);
                    secondPlayer += Time.deltaTime;
                }
                if (secondPlayer > damagePeriod)
                {
                    
                    playerHealth.playerHealth -= damageEnemy;
                    secondPlayer = 0;

                }
            }
            
        }
        if(attackActiv == false)
        {
            animator.SetBool("Attack", false);
            secondPlayer = 0;
        }


        stateMachine.Update();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackActiv = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackActiv = false;
        }
    }
}
