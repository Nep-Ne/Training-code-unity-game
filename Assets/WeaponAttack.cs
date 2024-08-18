using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public float damage=5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy" )
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }
}
