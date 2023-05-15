using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public GameObject Container;

    public GameObject Rung1Pref;
    private GameObject Rung1;
    public GameObject ScrollGun1Pref;
    private GameObject ScrollGun1;
    public int ObjContent1;
    public GameObject Empty24;
    public GameObject[] Empty1;

    public GameObject Rung2Pref;
    private GameObject Rung2;
    public GameObject ScrollGun2Pref;
    private GameObject ScrollGun2;
    public int ObjContent2;
    public GameObject[] Empty2;
    void Start()
    {
        Rung1 = Instantiate(Rung1Pref);
        Rung1.transform.SetParent(Container.transform);
        ScrollGun1 = Instantiate(ScrollGun1Pref);
        ScrollGun1.transform.SetParent(Container.transform);
        for(int i = 0; i < ObjContent1; i++)
        {
            Empty1[i] = Instantiate(Empty24);
            Empty1[i].transform.SetParent(Container.transform);
        }

        Rung2 = Instantiate(Rung2Pref);
        Rung2.transform.SetParent(Container.transform);
        ScrollGun2 = Instantiate(ScrollGun2Pref);
        ScrollGun2.transform.SetParent(Container.transform);
        for (int i = 0; i < ObjContent2; i++)
        {
            Empty2[i] = Instantiate(Empty24);
            Empty2[i].transform.SetParent(Container.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
