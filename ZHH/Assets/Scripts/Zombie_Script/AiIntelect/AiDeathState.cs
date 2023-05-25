using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    public Vector3 direction;
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        
        agent.ragdoll.ActivateRagdoll();
        agent.death = true;
        direction.y = 6;
        direction.x = -6;
        agent.ragdoll.ApplyForce(direction * agent.config.dieForce);
        agent.ui.gameObject.SetActive(false);
        agent.mesh.updateWhenOffscreen = true;
        
    }
    public void Update(AiAgent agent)
    {
        
    }

    public void Exit(AiAgent agent)
    {
        
    }

    

    
}
