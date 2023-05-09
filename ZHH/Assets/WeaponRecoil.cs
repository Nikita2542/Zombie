using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public RCC_Camera playerCamera;
    
    //[Header("Горизонтальная отдача")]
    //public float[] recoilPattern;

    [Header("Вертикальная отдача")]
    public float verticalRecoil;
    //[HideInInspector] public float horizontalRecoil;
    [Header("Время отдачи")]
    public float duration;
    public float durationTime;

    float time;
    float timeDur;

    int index;

    private void Awake()
    {
        
    }
    public void Start()
    {
       
       

    }
    public void Reset()
    {
        index = 0;
    }

    /*int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }*/
    public void GenerateRecoil()
    {
        time = duration;


        //horizontalRecoil = recoilPattern[index];


        //index = NextIndex(index);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            playerCamera.orbitY -= ((verticalRecoil / 100) * Time.deltaTime) / duration;
            //playerCamera.orbitX -= ((horizontalRecoil / 10) * Time.deltaTime) / duration;
            
                timeDur = durationTime;
            
            
            time -= Time.deltaTime;
            
        }
        if (time <= 0)
        {
            if (timeDur > 0)
            {
                playerCamera.orbitY += ((verticalRecoil / 100) * Time.deltaTime) / durationTime;
                //playerCamera.orbitX += ((horizontalRecoil / 10) * Time.deltaTime) / durationTime;
                timeDur -= Time.deltaTime;
            }
        }
            


    }
}
