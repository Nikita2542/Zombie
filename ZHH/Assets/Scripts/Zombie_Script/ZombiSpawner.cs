using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawner : MonoBehaviour
{
    
    public GameObject zombPrefab;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //Transform[] allchildren = this.transform.GetComponentsInChildren<Transform>(true);
        
        //for(int i = 0; i < allchildren.Length; i++)
        //{
        //    Instantiate(allchildren[i].transform, new Vector3(i * 2.0f, 0, i * 2.0f), Quaternion.identity);
        //}

            //for (var i = 0; i < 10; i++)
            //{
              //  Instantiate(zombPrefab.gameObject, new Vector3 (i * 2.0f, 0, i * 2.0f), Quaternion.identity);
            //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
