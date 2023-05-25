using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static RCC_Recorder;

public class AiChasePlayerState : AiState
{
    
   
    float timer = 0.0f;
    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }
    public void Enter(AiAgent agent)
    {
        
    }
    public void Update(AiAgent agent)
    {

        agent.navMeshAgent.stoppingDistance = 8f;
        if (!agent.enabled)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (agent.navMeshAgent.hasPath)
        {
           
                agent.navMeshAgent.destination = agent.playerTransform.position;
            


            
        }
        if (timer < 0.0f)
        {

            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0.0f;
            if (agent.distans > agent.distansPlayer)
            {
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }
            if (direction.sqrMagnitude > agent.config.minDistance * agent.config.minDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                   
                        agent.navMeshAgent.destination = agent.playerTransform.position;
                    

                }

            }
            timer = agent.config.maxTime;
        }



    }
    public void Exit(AiAgent agent)
    {

    }
}
