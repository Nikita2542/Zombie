using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    public AiAgent agent;
    

    public void Start()
    {
        agent = GetComponentInParent<AiAgent>();
    }

    public void OnRaycastHit(Gun_Zombie hit, Vector3 direction)
    {
        if(gameObject.tag == "Head")
        {
            health.TakeDamage(hit.damage_gun + 10, direction);
        }
        else
        {
            health.TakeDamage(hit.damage_gun, direction);
        }
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(agent.speedometr.speedCAR > 20)
            {
                agent.mainCar = true;
            }
            
        }
    }
}
