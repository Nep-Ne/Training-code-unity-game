using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float hp = 2;
    public float atk = 5;
    public float exp = 0;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHurt()
    {
        hp--;
        // animator.SetTrigger("GetHurt");
        // Debug.Log(hp);
    }
    public void Recover()
    {
        hp++;
    }
    public void Attack()
    {

    }
    public void Death()
    {

    }
}
