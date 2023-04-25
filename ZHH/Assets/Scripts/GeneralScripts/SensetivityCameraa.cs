using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensetivityCameraa : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity;
    public Vector3 delteMove;
    public float speed;
    public GameObject mover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}
