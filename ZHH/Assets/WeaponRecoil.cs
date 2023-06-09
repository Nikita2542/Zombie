using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public RCC_Camera playerCamera;

    //[Header("�������������� ������")]
    [Header("�������������� ������")]
    public float[] recoilPattern;

    [Header("������������ ������")]
    public float verticalRecoil;
    public float verticalRecoilReset;
    [HideInInspector] public float horizontalRecoil;

    [Header("����� ������")]
    public float duration;
    public float durationTime;

    float time;
    float timeDur;

    int index;

    public void Reset()
    {
        index = 0;
    }

    int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }
    public void GenerateRecoil()
    {
        time = duration;

        horizontalRecoil = recoilPattern[index];

        index = NextIndex(index);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        // ������ �����
        if(time > 0)
        {
            playerCamera.orbitY -= ((verticalRecoil / 100) * Time.deltaTime) / duration;
            playerCamera.orbitX -= ((horizontalRecoil / 100) * Time.deltaTime) / duration;

            time -= Time.deltaTime;
            
        }
        if (time < 0)
        {
            timeDur = durationTime;
            time = 0;
        }
        // ������ ����
        if (timeDur > 0)
        {
            playerCamera.orbitY += ((verticalRecoilReset / 100) * Time.deltaTime) / durationTime;
            
            timeDur -= Time.deltaTime;

        }

    }
}
