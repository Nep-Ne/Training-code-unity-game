using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    Slider Fill;
    public GameObject enemy;
    float maxHealth;
    float HP;
    private void Start()
    {
        Fill = GetComponent<Slider>();
        HP = enemy.GetComponent<EnemyController>().health;
        maxHealth= enemy.GetComponent<EnemyController>().maxhealth;
        SetMaxHealth(maxHealth);
        SetHealth(HP);
    }
    private void Update()
    {
        SetHealth(enemy.GetComponent<EnemyController>().health);
    }



    public void SetMaxHealth(float maxHP)
    {
        Fill.maxValue = maxHP;
    }
    public void SetHealth(float HP)
    {
        if (HP > maxHealth)
        {
            HP = maxHealth;
            enemy.GetComponent<EnemyController>().health = maxHealth;//dam bao current hp khong bao gio vuot qua maxhp
        }

        Fill.value = HP;
    }

}
