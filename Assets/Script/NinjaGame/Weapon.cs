using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void ActiveWeapon()
    {
        //GameObject weapon = GameObject.Find("weapon");
        //weapon.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        if(gameObject.CompareTag("Pistol"))
        {
            gameObject.SetActive(true);
        }
    }
    
}
