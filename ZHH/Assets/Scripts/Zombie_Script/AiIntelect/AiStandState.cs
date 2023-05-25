using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AiStandState : AiState
{

    bool UpActive;
    float secondUp;
    float secondDown;

    public AiStateId GetId()
    {
        return AiStateId.StandUp;
    }

    public void Enter(AiAgent agent)
    {
        
            
            
            
           
        
        
        
    }

    public void Exit(AiAgent agent)
    {
        
    }

   
    public void Update(AiAgent agent)
    {
        
       
        if (secondUp < 5.0f)
        {
            if(UpActive == false)
            {
                agent._isPointWalk = false;
                secondUp += Time.deltaTime;
                agent.hips.transform.parent = null;
                agent.mainObject.transform.position = agent.hips.transform.position;
                agent.mainObject.gameObject.transform.position = agent.hips.transform.position;
               
            }
        }
        if (secondUp >= 5.0f)
        {
            if(UpActive == false)
            {
               
                agent.hips.transform.SetParent(agent.armature.transform);
                agent.ragdoll.ActivateRagdollStandUp();
                agent.animator.SetTrigger("StandUp");
                agent.navMeshAgent.stoppingDistance = 100;
                agent.mainCar = false;
                agent._isAttack = false;
                UpActive = true;
                
            }
        }
        if(UpActive == true)
        {
            secondUp = 0; 
            if (secondDown < 1.4f)
            {
                secondDown += Time.deltaTime;

            }
           
            if (secondDown >= 1.4f)
            {
                
                agent.animator.SetTrigger("IdleStand");
                agent.stateMachine.ChangeState(AiStateId.Idle);
                agent.ui.gameObject.SetActive(true);
                agent._isPointWalk = true;
                agent._isAttack = true;
                UpActive = false;
                secondDown = 0;
                

            }
        }
        

        

    }
}
