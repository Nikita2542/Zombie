using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    //public GameObject[] objScroll;
    public GameObject[] emptyObj;
    public GameObject scroll;

    public Button btnOpen;
    public Button btnClose;
    //public GameObject empty;
    //public GameObject container;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        btnClose.gameObject.SetActive(true);
        btnOpen.gameObject.SetActive(false);
        scroll.SetActive(true);
        for (int i = 0; i < emptyObj.Length; i++)
        {
            emptyObj[i].SetActive(true);
        }
    }
    public void Close()
    {
        btnClose.gameObject.SetActive(false);
        btnOpen.gameObject.SetActive(true);
        scroll.SetActive(false);
        for (int i = 0; i < emptyObj.Length; i++)
        {
            emptyObj[i].SetActive(false);
        }
    }
}
