using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AiAttackState : AiState
{
    
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }
    public void Enter(AiAgent agent)
    {
        
        
    }

    public void Update(AiAgent agent)
    {
        
       
            
                if (agent.ActiveAttack == true)
                {
                    if (agent.playerHealth.playerHealth > 0)
                    {
                        if (agent.secondPlayer < agent.damagePeriod)
                        {

                            agent.secondPlayer += Time.deltaTime;
                        }
                        if (agent.secondPlayer > agent.damagePeriod)
                        {
                            agent.animator.SetTrigger("Attack");
                            agent.playerHealth.playerHealth -= agent.config.damageEnemy;
                            agent.secondPlayer = 0;

                        }
                    }
                }
                else              
                {

                    agent.animator.SetTrigger("IdleAttack");
                   // agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
                    agent.stateMachine.ChangeState(AiStateId.Idle);

                }
            
            
        
        
       
            

        
       



    }

    public void Exit(AiAgent agent)
    {
        
    }

    

   
}
