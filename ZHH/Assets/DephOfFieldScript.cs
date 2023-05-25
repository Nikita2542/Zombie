using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class DephOfFieldScript : MonoBehaviour
{
    public Gun_Zombie gun;
    private ZoomScoupSniper sniper;
   

    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;
  
    public float focusSpeed;
    public Volume volume;
    VolumeProfile postProcessing;



    //public Volume volume;


   
    //public VolumeProfile profile1;
   
    //*-+.467   


    //public GameObject DephOf;

   
    void Start()
    {
        postProcessing = volume.profile;
        sniper = gun.gameObject.GetComponent<ZoomScoupSniper>();
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
        raycast = new Ray(transform.position, transform.forward * gun.OptionGun.range_gun);

        isHit = false;

        if(Physics.Raycast(raycast, out hit, gun.OptionGun.range_gun))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if(hitDistance < gun.OptionGun.range_gun)
            {
                hitDistance++;
            }
        }

        SetFocus();
    }

    void SetFocus()
    {

        DepthOfField dephOfField;
        if(postProcessing.TryGet(out  dephOfField))
        {
            dephOfField.focusDistance.value = Mathf.Lerp(dephOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
            if(sniper.scoupActive8X == true)
            {
                dephOfField.aperture.value = 1f;
                dephOfField.focalLength.value = 200f;
            }
            else
            {
                dephOfField.aperture.value = 2f;
                dephOfField.focalLength.value = 150f;
            }
        }
        
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
