using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public RCC_Camera playerCamera;
    public float verticalRecoil;
    public float duration;

    float time;
    public void GenerateRecoil()
    {
        time = duration;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            playerCamera.orbitY -= ((verticalRecoil / 100) * Time.deltaTime) / duration;
            
            time -= Time.deltaTime;
        }
       
        
    }
}
