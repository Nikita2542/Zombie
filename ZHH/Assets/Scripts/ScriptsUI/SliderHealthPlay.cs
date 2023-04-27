using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderHealthPlay : MonoBehaviour
{
    public EnemiRun enemiRun;
    public Text textHealth;
    public Slider sliderPlayer;
    public Image fillPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        textHealth.text = enemiRun.Player_Health.ToString();
       
        sliderPlayer.value = enemiRun.Player_Health;

        if (enemiRun.Player_Health == 100) 
        {
            fillPlayer.color = Color.green;
            textHealth.color = Color.white; 
        }
        if (enemiRun.Player_Health == 50)
        {
            fillPlayer.color = Color.yellow;
            textHealth.color = Color.yellow;
        }
        if (enemiRun.Player_Health == 25)
        {
            fillPlayer.color = Color.red;
            textHealth.color = Color.red;
        }
    }

    
}
