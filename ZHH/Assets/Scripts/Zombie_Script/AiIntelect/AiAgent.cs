using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    
   
    [Space(5)]
    public AiStateId initialState;
    public AiAgentConfig config;
    
    [Header("Настройка дистанции")]
    [Space(5)]
    public float RadiusAttackPlayer;
    public float RadiusAttack;
    public float RadiusAttackStandart;
    public float RadiusWalk;
    [Header("Скорость")]
    [Space(5)]
    public float EnemySpeed;
    public float EnemyMaxSpeed;

    [Header("Дистанция до игрока")]
    [Space(5)]
    public float distansPlayer;
    [HideInInspector] public float distans;  
    [HideInInspector] public float pointDistanse;





    //---------------------------------------------------------
    

    [HideInInspector] public AiStateMachine stateMachine;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Ragdoll ragdoll;
    [HideInInspector] public HitBox[] hitBox;
    [HideInInspector] public SkinnedMeshRenderer mesh;
    [HideInInspector] public UIHealthBar ui;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public Health health;
    [HideInInspector] public Animator animator;
    [HideInInspector] public LayerMask _layerPlayer;
    [HideInInspector] public LayerMask _layerGround;
    [HideInInspector] public Transform _playerTransform;
    [HideInInspector] public Vector3 _pointWalk;

    [HideInInspector] public bool attackActiv;
    [HideInInspector] public float second;
    [HideInInspector] public float RadiusAttackCurrent;
    [HideInInspector] public float secondPlayer;
    [HideInInspector] public float damagePeriod;
    public bool _isAttack;
    public bool _Attack;
    public bool _isPointWalk;
    public bool mainCar;
    public bool ActiveAttack;
    public bool death;
   


    [HideInInspector] public GameObject hips;
    [HideInInspector] public GameObject armature;
    [HideInInspector] public GameObject mainObject;
    [Header("Позиция дома")]
    [Space(5)]
    public GameObject PointObj;


    [Header("Скрипты")]
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public Speedometr speedometr;
    // Start is called before the first frame update
    void Start()
    {
        _isPointWalk = false;
        death = false;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        speedometr = GameObject.FindGameObjectWithTag("Player").GetComponent<Speedometr>();

        mainObject = gameObject;
        armature = mainObject.transform.GetChild(0).gameObject;
        hips = armature.transform.GetChild(0).gameObject;
        
        _layerPlayer = LayerMask.GetMask("RCC");
        _layerGround = LayerMask.GetMask("Ground");

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
    // -------------------------------------------------------------------------------------
    void FixedUpdate()
    {
       

    }
    public void Pattrolling()
    {
        navMeshAgent.stoppingDistance = 0;
        if (_isPointWalk == true)
        {
            navMeshAgent.SetDestination(_pointWalk);

            if (Vector3.Distance(transform.position, _pointWalk) < 1)
            {
                _isPointWalk = false;
            }
        }
        else
        {
            SetRandomWalkPoint();
        }
    }
    public void SetRandomWalkPoint()
    {
        float ranX = Random.Range(-RadiusWalk, RadiusWalk);
        float ranZ = Random.Range(-RadiusWalk, RadiusWalk);

        _pointWalk = new Vector3(PointObj.transform.position.x + ranX, PointObj.transform.position.y, PointObj.transform.position.z + ranZ);

        Collider[] colliders = Physics.OverlapSphere(_pointWalk, 1);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Wall")
            {
                _isPointWalk = false;
                return;
            }
        }

        if (Physics.Raycast(_pointWalk, -Vector3.up, 5, _layerGround))
        {
            _isPointWalk = true;
            return;
        }
        else
        {
            _isPointWalk = false;
            return;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusAttackStandart);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadiusAttackCurrent);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(PointObj.transform.position, RadiusWalk);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, RadiusAttackPlayer);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, RadiusAttack);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_pointWalk, 1);
    }

    //---------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    { //---------------------------------------------------------------------------------------
        _Attack = Physics.CheckSphere(transform.position, RadiusAttack, _layerPlayer);
        if (_Attack == true)
        {           
            attackActiv = true;
        }
        else
        {
            attackActiv = false;
        }
            distans = Vector3.Distance(transform.position, playerTransform.position);
        pointDistanse = Vector3.Distance(transform.position, PointObj.transform.position);
        //------------------------------
       
        if (mainCar == true)
        {
            _Attack = false;
            _isPointWalk = false;
            ragdoll.ActivateRagdoll();
            stateMachine.ChangeState(AiStateId.StandUp);
        }
        if(mainCar == false)
        {
            if (attackActiv == true)
            {
                ActiveAttack = true;
                stateMachine.ChangeState(AiStateId.Attack);
            }
            else
            {
                ActiveAttack = false;

            }
        }
       
       


            stateMachine.Update();
    }
    /*public void OnTriggerEnter(Collider other)
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
    }*/
}
