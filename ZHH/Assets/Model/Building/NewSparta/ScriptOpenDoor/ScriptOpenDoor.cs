using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOpenDoor : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    
    public float run_open;
    private int inOpen;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(inOpen == 1)
        {
            
                
            transform.position = Vector3.MoveTowards(transform.position, open.transform.position, Time.deltaTime * run_open);
                
            
        }
        if (inOpen == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, close.transform.position, Time.deltaTime * run_open);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            inOpen = 1;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            inOpen = 2;
        }
    }
}
