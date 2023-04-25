using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderHealthPlay : MonoBehaviour
{
    public Slider sliderPlayer;
    public Image fillPlayer;
    public int health;

    public GameObject IntveMain;
    // Start is called before the first frame update
    void Start()
    {
        IntveMain.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            IntveMain.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        
        sliderPlayer.value = health;
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            health = PlayerPrefs.GetInt("PlayerHealth");
        }
        if (health == 100) 
        {
            fillPlayer.color = Color.green;
        }
        if (health == 50)
        {
            fillPlayer.color = Color.yellow;
        }
        if (health == 25)
        {
            fillPlayer.color = Color.red;
        }
    }

    public void ExiteMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Contine()
    {
        IntveMain.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
