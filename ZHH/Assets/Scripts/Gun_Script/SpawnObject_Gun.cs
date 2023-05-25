using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObject_Gun : MonoBehaviour
{
    public GameObject[] prefab_pricel;
    public GameObject pricel;
    public GameObject parent;

    public int Clone_ID;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("ID"))
        {
            Clone_ID = PlayerPrefs.GetInt("ID");
        }

        if (Clone_ID == 1)
        {
            pricel = Instantiate(prefab_pricel[0], parent.transform);
            
        }

        if (Clone_ID == 2)
        {
            pricel = Instantiate(prefab_pricel[1], parent.transform);

        }
        if (Clone_ID == 3)
        {
            pricel = Instantiate(prefab_pricel[2], parent.transform);
            
        }
    }
    public void Garage()
    {
        SceneManager.LoadScene(1);
    }
}
