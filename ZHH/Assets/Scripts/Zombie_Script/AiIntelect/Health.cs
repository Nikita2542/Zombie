using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using static MainZombieScript;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Health : MonoBehaviour
{

     public float maxHealth;
    public GunOptionsMain gunOptions;
    
    [HideInInspector]
    public GameObject slizClone;
     public GameObject slizPrefab;
     public GameObject slizTarget;
    public GameObject targetGun;
    public GameObject hips;
     public GameObject Armature;

    public Image rem;
    private float remSec;
    private bool remActiv;

    
    
    
    [HideInInspector]
        public float currentHealth;
    
    AiAgent agent;
    
    SkinnedMeshRenderer skinnedMeshRenderer;
    
    UIHealthBar healthBar;
    
    Ragdoll ragdoll;
    

     public float blinkIntensity;
     public float blinkDuration;
    float blinkTimer;

    float slizSpeed = 15.0f;

    [HideInInspector] public int slizYellow;

    private bool slizPickup = false;
    
    
    float secundDead;
    float second;
    // Start is called before the first frame update
    void Start()
    {
        rem.gameObject.SetActive(false);
        agent = GetComponent<AiAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;

        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies)
        {
            HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
        }
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        if(currentHealth <= 0.0f)
        {
            if(slizClone == null)
            {
                slizClone = Instantiate(slizPrefab, slizTarget.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            }
            RemEvent();
            Die(direction);
        }
        blinkTimer = blinkDuration;
    }
    public void RemEvent()
    {
        remActiv = true;
        rem.gameObject.SetActive(true);      
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
            slizPickup = true;
            PlayerPrefs.SetInt("sliz_yellow", slizYellow);
            DieSlizz();

            PlayerPrefs.Save();
        }
    }
    void DieNevor()
    {
        Destroy(gameObject);
    }

    private void Die(Vector3 direction)
    {
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        deathState.direction = direction;
        agent.stateMachine.ChangeState(AiStateId.Death);
    }
   
    public void AttackHealz()
    {
        agent.stateMachine.ChangeState(AiStateId.Attack);
    }
    
  
    void DieSlizz()
    {
        Destroy(slizClone);
    }
    
    private void Update()
    {
        if (PlayerPrefs.HasKey("sliz_yellow"))
        {
            slizYellow = PlayerPrefs.GetInt("sliz_yellow");
        }
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.materials[0].color = Color.white * intensity;
        skinnedMeshRenderer.materials[1].color = Color.white * intensity;
        skinnedMeshRenderer.materials[2].color = Color.white * intensity;
        skinnedMeshRenderer.materials[3].color = Color.white * intensity;
        if (remActiv == true)
        {
            if (remSec < 1)
            {
                remSec += Time.deltaTime;
            }
            if (remSec >= 1)
            {
                rem.gameObject.SetActive(false);
                remSec = 0;
                remActiv = false;
            }
        }
        
        
        if(agent.navMeshAgent.speed == 0)
        {
            AttackHealz();
        }
        if (gunOptions.gunSlizator == true)
        {
            if (Input.GetMouseButton(1))
            {
                if (slizClone)
                {
                    Sslizator();
                }
            }           
        }
        if (slizPickup == true)
        {
            if (secundDead < 5)
            {
                secundDead += Time.deltaTime;
            }
            if (secundDead >= 5)
            {
                slizPickup = false;
                secundDead = 0;
                DieNevor();
            }
        }
    }
}
