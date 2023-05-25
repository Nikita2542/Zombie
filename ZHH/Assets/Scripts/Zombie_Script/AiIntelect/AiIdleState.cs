using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RCC_Recorder;
using UnityEngine.AI;

public class AiIdleState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    public void Enter(AiAgent agent)
    {
        
    }
    public void Update(AiAgent agent)
    {

        
        agent._isAttack = Physics.CheckSphere(agent.transform.position, agent.RadiusAttackCurrent, agent._layerPlayer);
        if (agent._isAttack == true)
        {
            if(agent.mainCar == false)
            {
                
                Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;

                if (playerDirection.magnitude < agent.config.maxSightDistance)
                {
                    return;
                }
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
                agent.RadiusAttackCurrent = agent.RadiusAttackPlayer;
                agent.navMeshAgent.speed = agent.EnemyMaxSpeed;

                playerDirection.Normalize();
            }
            
        }
        else
        {
            
           
            agent.Pattrolling();

            agent.RadiusAttackCurrent = agent.RadiusAttackStandart;
            
            if(agent.pointDistanse > agent.RadiusWalk)
            {
                agent.navMeshAgent.speed = agent.EnemyMaxSpeed;
            }
            else
            {
                agent.navMeshAgent.speed = agent.EnemySpeed;
            }

        }


       

       

       

        
    }

    public void Exit(AiAgent agent)
    {
        
    }

    

   
}
