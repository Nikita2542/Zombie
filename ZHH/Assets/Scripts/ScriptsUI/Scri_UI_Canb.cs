using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scri_UI_Canb : MonoBehaviour
{
    public GameObject CanvaUI;
    public GameObject player_UI;
    public float SpeedLookRoot;

    

    // Start is called before the first frame update
    void Start()
    {
        CanvaUI.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = (player_UI.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * SpeedLookRoot);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvaUI.SetActive(false);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvaUI.SetActive(true);
        }
    }
    
}
