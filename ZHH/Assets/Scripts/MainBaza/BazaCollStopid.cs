using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class BazaCollStopid : MonoBehaviour
{

    
    public RCC_CarControllerV3 CarController;
    



    public GameObject playerCar;
    public GameObject playerCarPref;
    public GameObject bazaColl;
   
   

    
    public GameObject PlatformUp;
    public GameObject PosUp;
    public GameObject PosDown;
    public GameObject PosUpCar;

    public GameObject HomeCar;

    private float speed_Up = 0.1f;

    public Camera camMain;
    public Camera camLab;
    public Camera camGrid;
    public RectTransform Rect_21;

    private int inputE;    
    private float speedPlayerRoot = 20;
    private int secundomer = 2;

    public GameObject MainInterfeis;


    

    private Vector2 turn;

    [Range(0f, 10f)] public float sensitivity = 3f;


    void Start()
    {
        MainInterfeis.SetActive(false);
        playerCar = Instantiate(playerCarPref, HomeCar.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        CarController = playerCar.GetComponent<RCC_CarControllerV3>();
        
        camMain.enabled = true;
        camLab.enabled = false;
        camGrid.enabled = false;
        speedPlayerRoot = 10;
        secundomer = 0;
        Rect_21 = Rect_21.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        



        if (secundomer == 1)
        {
            
            EventStartUpPlatform();
        }
        if(secundomer == 2)
        {
            
            EventExtUpPlatform();
        }
            
            
        

        if (inputE == 1)
        {


            EventRootateCar();


            if (Input.GetKey(KeyCode.E))
            {
                MainInterfeis.SetActive(true);
                secundomer = 1;
                Destroy(playerCar);
                EventStopLaborator();

            }

            if(Input.GetKey(KeyCode.Q))
            {
                MainInterfeis.SetActive(false);
                secundomer = 2;
                Destroy(playerCar);
                EventStartLaborator();
                
                

            }
        }
     
        

    }


    public void OnTriggerEnter(Collider other)
    {




        if (other.CompareTag("Player"))
        {
            inputE = 1;
        }




    }

    public void OnTriggerExit(Collider other)
    {
        


        if(other.CompareTag("Player"))
        {
            inputE = 0;
        }



    }



    public void EventStopLaborator()
    {

        playerCar = Instantiate(playerCarPref, bazaColl.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        CarController = playerCar.GetComponent<RCC_CarControllerV3>();
        
        CarController.canControl = false;
        camMain.enabled = false;
        camLab.enabled = true;
        
        

    }

    public void EventStartLaborator()
    {

        playerCar = Instantiate(playerCarPref, bazaColl.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        CarController = playerCar.GetComponent<RCC_CarControllerV3>();
        
        
        CarController.canControl = true;
        inputE = 0;
        camLab.enabled = false;
        camMain.enabled = true;
        




    }

    public void EventRootateCar()
    {



        if (RectTransformUtility.RectangleContainsScreenPoint(Rect_21, Input.mousePosition))
        {
            


            if (Input.GetMouseButton(1))
            
            {


                turn.x += Input.GetAxis("Mouse X") * sensitivity;
                
                playerCar.transform.localRotation = Quaternion.Euler(0, -turn.x, 0);
                PlatformUp.transform.localRotation = Quaternion.Euler(0, -turn.x, 0);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked; //Блокировка курсора


            }
            else
            {


                UnityEngine.Cursor.lockState = CursorLockMode.None; //Разблокировка курсора
                return;


            }
            


        }



    }

    public void EventStartUpPlatform()
    {
        inputE = 1;
        PlatformUp.transform.position = Vector3.MoveTowards(PlatformUp.transform.position, PosUp.transform.position, Time.deltaTime * speed_Up);
        bazaColl.transform.position = Vector3.MoveTowards(bazaColl.transform.position, PosUpCar.transform.position, Time.deltaTime * speed_Up);
    }
    public void EventExtUpPlatform() 
    {
        PlatformUp.transform.position = Vector3.MoveTowards(PlatformUp.transform.position, PosDown.transform.position, Time.deltaTime * speed_Up);
    }

    
}
