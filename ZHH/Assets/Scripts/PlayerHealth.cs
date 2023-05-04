using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class PlayerHealth : MonoBehaviour
{
    
    
    public int playerHealthMax;
    public int playerHealth;
    public Text textHealth;
    public Slider sliderPlayer;
    public Image fillPlayer;
    // Start is called before the first frame update
    void Start()
    {      
        playerHealth = playerHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        textHealth.text = playerHealth.ToString();

        sliderPlayer.value = playerHealth;

        if (playerHealth == 100)
        {
            fillPlayer.color = Color.green;
            textHealth.color = Color.white;
        }
        if (playerHealth <= 50)
        {
            fillPlayer.color = Color.yellow;
            textHealth.color = Color.yellow;
        }
        if (playerHealth <= 25)
        {
            fillPlayer.color = Color.red;
            textHealth.color = Color.red;
        }
        if(playerHealth == 0)
        {
            
               
            
            
        }
    }
}
