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
    [HideInInspector] public Ragdoll ragdoll;
    [HideInInspector] public HitBox[] hitBox;
    [HideInInspector] public SkinnedMeshRenderer mesh;
    [HideInInspector] public UIHealthBar ui;
    [HideInInspector] public Transform playerTransform;

    [HideInInspector] public Health health;

    public GameObject hips;
    public GameObject armature;
    public GameObject mainObject;

   
    

    public bool mainCar;
    [HideInInspector] public bool attackActiv;
    [HideInInspector] public float second;
     public float secondPlayer;

    [HideInInspector] public Animator animator;
    public float damagePeriod;
    public bool ActiveAttack;
    // Start is called before the first frame update
    void Start()
    {
        
        ragdoll = GetComponent<Ragdoll>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        hitBox = GetComponentsInChildren<HitBox>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();


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

        if (mainCar == true)
        {
            ragdoll.ActivateRagdoll();
            stateMachine.ChangeState(AiStateId.StandUp);
        }
        if(mainCar == false)
        {
            
            
        }
        if(attackActiv == true)
        {
            ActiveAttack = true;
            stateMachine.ChangeState(AiStateId.Attack);
        }
        if (attackActiv == false)
        {
            
            ActiveAttack = false;
            
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
