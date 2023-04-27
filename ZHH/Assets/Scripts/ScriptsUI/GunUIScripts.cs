using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIScripts : MonoBehaviour
{
    public Gun_Zombie gun_Zombie;
    public GameObject contentBulled;
    public GameObject contentBulledMax;

    public int bulledInt;

    public Image cloneBulled;
    public Image cloneBulledMax;
    public Image ItemBulledMax;
    public Image ItemBulled;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gun_Zombie.OptionGun.bulletMax; i++)
        {
            cloneBulledMax = Instantiate(ItemBulledMax);
            cloneBulledMax.transform.SetParent(contentBulledMax.transform);
        }
        for (int i = 0; i < gun_Zombie.OptionGun.bulletMax; i++)
        {
            cloneBulled = Instantiate(ItemBulled);         
            cloneBulled.transform.SetParent(contentBulled.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
        //BulledUpdate();
        //for (int i = 0; i < gun_Zombie.OptionGun.bullet; i++)
        //{
        //    cloneBulled = Instantiate(ItemBulled);
        //    cloneBulled.transform.SetParent(contentBulled.transform);
        //}


    }
    
}
