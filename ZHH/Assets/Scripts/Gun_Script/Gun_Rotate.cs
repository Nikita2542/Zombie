using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Rotate : MonoBehaviour
{
    public GameObject gun_obj;
    public GameObject cam_target;
    

    public void Update()
    {
        
        Vector3 targetpos_cam = new Vector3(cam_target.transform.position.x, gun_obj.transform.position.y , cam_target.transform.position.z);
        gun_obj.transform.LookAt(targetpos_cam);
        //newDirection_gun = Vector3.RotateTowards(gun_obj.forward, cam_target.position, 0.01f, 10);
    }
}
