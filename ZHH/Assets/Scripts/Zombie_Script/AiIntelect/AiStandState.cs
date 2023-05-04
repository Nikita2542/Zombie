using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AiStandState : AiState
{

    private bool UpActive;
    private float secondUp;
    private float secondDown;

    public AiStateId GetId()
    {
        return AiStateId.StandUp;
    }

    public void Enter(AiAgent agent)
    {
        if(agent.speedometr.speedCAR > 20)
        {
            UpActive = false;
            secondUp = 0;
            secondUp = 0;
            agent.ragdoll.ActivateRagdoll();
            agent.ui.gameObject.SetActive(false);
        }
        
        
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
                agent.mainCar = false;
                UpActive = false;
                secondDown = 0;
                
                
            }
        }
        

        

    }
}
