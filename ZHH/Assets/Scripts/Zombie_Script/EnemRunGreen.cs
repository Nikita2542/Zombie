using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemRunGreen : MonoBehaviour
{
    public Transform player;
    public Transform home;
    public float speed;

    public int homePoint;
    private void Update()
    {

        float dist = Vector3.Distance(player.position, transform.position);
        float distHome = Vector3.Distance(home.position, transform.position);
        Debug.Log(dist);
        if(dist >= 10) 
        {          
           
            
            if(transform.position == home.position)
            {
                homePoint = 1;
                
            }
            if(homePoint == 1)
            {
                if (transform.position.x < 7.4f)
                {
                    speed = -speed;
                }
                if (transform.position.x > -10f)
                {
                    speed = 2;
                }
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
           
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        if(distHome >= 10)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, home.position, step);
        }
    }
    

}
