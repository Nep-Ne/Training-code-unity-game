using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public float HP=5f;
    public float maxHP = 8f;
    public float ATK = 5f;
    public float EXP = 0f;
    //private Animator animator;

    //public HealthBar healthbar;//gan gameobject nao co script HealthBar vao cai inspector script nay la ok!!!

    //neu su dung cach Update healthbar ben script Healthbar thi doan code duoi khong can thiet !!!
    //void Update()
    //{
    //    healthbar.SetHealth(HP);
    //}


    public void GetHurt(float damageAmount)
    {

        HP = HP - damageAmount;
       // animator.SetTrigger("GetHurt");
        Debug.Log(HP);

    }
    public void Heal(float healAmount)
    {
        HP += healAmount;
    }
    public void Attack()
    {

    }
    public void Death()
    {

    }
}
