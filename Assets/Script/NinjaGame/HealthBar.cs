using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Slider Fill;
    //public GameObject player;
    //PlayerStat stat;
    public PlayerStat stat;//gan gameobject co component PlayerStat la ok !! (script cung la 1 component !!!)
    void Start()
    {
        Fill = GetComponent<Slider>();
        //stat = player.GetComponent<PlayerStat>();
        SetMaxHealth(stat.maxHP);
        SetHealth(stat.HP);
    }

    //ham Update nay khong can thiet neu nhu da su dung cai update ben PlayerStats !!
    void Update()
    {
        SetMaxHealth(stat.maxHP);
        SetHealth(stat.HP);
    }


    public void SetMaxHealth(float maxHP)
    {
        Fill.maxValue = maxHP;
    }

    public void SetHealth(float HP)
    {
        if (stat.HP > stat.maxHP) stat.HP = stat.maxHP;//dam bao current hp khong bao gio vuot qua maxhp
        Fill.value = HP;
    }
}
