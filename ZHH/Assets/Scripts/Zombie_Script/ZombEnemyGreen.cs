using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombEnemyGreen : MonoBehaviour
{
    [SerializeReference]
    public float health_zomb = 100f;

    [SerializeReference]
    public GameObject Sliz_Green;
    public GameObject target;

    [SerializeReference]
    private GameObject Zomb_green;
    private GameObject Sliz_Green_Go;

    private int speed_sliz = 30;
    private int sliz_green;
    private int slizator_true;
    public void TakeDamage_gun(float amount)
    {
        health_zomb -= amount;
        if (health_zomb <= 0)
        {
            if (Zomb_green.CompareTag("Zombie_green"))
            {
                Sliz_Green_Go = Instantiate(Sliz_Green, Zomb_green.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                Die();
            }
        }
    }

    public void Update()
    {
        if (PlayerPrefs.HasKey("sliz_green_main"))
        {
            sliz_green = PlayerPrefs.GetInt("sliz_green_main");
        }
        if (PlayerPrefs.HasKey("slizator_true"))
        {
            slizator_true = PlayerPrefs.GetInt("slizator_true");
        }
        if (slizator_true == 1)
        {
            if (Input.GetMouseButton(1))
            {
                Sslizator();
            }
        }
    }
    public void Sslizator()
    {
        Sliz_Green_Go.transform.position = Vector3.MoveTowards(Sliz_Green_Go.transform.position, target.transform.position, Time.deltaTime * speed_sliz);
        Vector3 direction = (target.transform.position - Sliz_Green_Go.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Sliz_Green_Go.transform.rotation = Quaternion.Lerp(Sliz_Green_Go.transform.rotation, lookRotation, Time.deltaTime * speed_sliz);
        if (Sliz_Green_Go.transform.position == target.transform.position)
        {
            sliz_green++;
            Die_Slizz();
            PlayerPrefs.SetInt("sliz_green", sliz_green);
            PlayerPrefs.Save();
        }
    }
    void Die_Slizz()
    {
        Destroy(Sliz_Green_Go);
    }
    void Die()
    {
        Destroy(Zomb_green);
    }
}
