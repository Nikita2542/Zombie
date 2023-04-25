using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUpBaza : MonoBehaviour
{
    public GameObject Garag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Garag.transform.position = Input.mousePosition;
        }
        
    }
}
