using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Experimental.Rendering.Universal;

public class DephOfFieldScript : MonoBehaviour
{
    
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;



    //public Volume volume;


    DepthOfField dofComponent;
    //public VolumeProfile profile1;
   
    //*-+.467   


    //public GameObject DephOf;

   
    void Start()
    {
       /* Volume volume = gameObject.GetComponent<Volume>();
        DepthOfField tmp;
        if (volume.profile.TryGet<DepthOfField>(out tmp))
        {
            dofComponent = tmp;
        }
        profile1 = volume.GetComponent<Volume>().profile;
        
        //depthOfField2 = profile1.GetComponent<DepthOfField>().focusDistance.value;

        volume = gameObject.GetComponent<Volume>();
       
        */

    }
   

    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);

        isHit = false;

        if(Physics.Raycast(raycast, out hit, 100))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if(hitDistance < 100)
            {
                hitDistance++;
            }
        }

        SetFocus();
    }

    void SetFocus()
    {
        
        
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.1f);

            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));



        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}
