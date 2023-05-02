using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AiStandState : AiState
{

    
    
    public AiStateId GetId()
    {
        return AiStateId.StandUp;
    }

    public void Enter(AiAgent agent)
    {
        if(agent.speedometr.speedCAR > 20)
        {
            agent.ragdoll.ActivateRagdoll();
        }
        
        
    }

    public void Exit(AiAgent agent)
    {
        
    }

   
    public void Update(AiAgent agent)
    {
        if (agent.second < 5)
        {
            agent.hips.transform.parent = null;
            agent.mainObject.transform.position = agent.hips.transform.position;
            agent.mainObject.gameObject.transform.position = agent.hips.transform.position;

        }


        if (agent.second >= 5)
        {
            agent.hips.transform.SetParent(agent.armature.transform);
            agent.ragdoll.ActivateRagdollStandUp();
            agent.stateMachine.ChangeState(AiStateId.Idle);
            agent.mainCar = false;
            agent.second = 0;
        }

    }
}
