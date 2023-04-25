using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometr : MonoBehaviour
{
    public Rigidbody target;

    public float speedCAR = 0.0f;
    public float maxSpeed = 0.0f; // ������������ �������� **

    [Header("UI")]
    public Text speedLabel; // ������� �� ����� ��������;

    
    private void Update()
    {
        // 3.6f ������������ � ��
        // ** ������ �� ��������� ������ **
        speedCAR = target.velocity.magnitude * 3.6f;
        PlayerPrefs.SetFloat("speedCAR", speedCAR);
        if (speedLabel != null)
            speedLabel.text = ((int)speedCAR) + " km/h";
    }
}
