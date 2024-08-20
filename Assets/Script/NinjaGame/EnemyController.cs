using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    Transform Player;
    //public Transform village;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;
    public float speed = 4f;
    public float health = 10f;
    public float maxhealth = 10f;
    [SerializeField] private GameObject floatingText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(animator.GetBool("Death")==false)
        Chase(Player);
    }

    void Chase(Transform target)
    { 
        float distance = Vector2.Distance(target.position, transform.position);
        direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        rb.velocity = direction.normalized* speed ;
        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
        animator.SetBool("Moving", true);
    }

    public void Death()
    {
        animator.SetBool("Death", true);
        Debug.Log("Death");
        //lam cho ke thu ko con collider de nguoi choi co the di qua animation death !!
        Destroy(gameObject.GetComponent<Collider2D>());

        //lam cho ke thu khong bi vang di sau khi bi dinh dan
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ShowDamage(dmg);
        if (health<=0)
        {
            Death();
        }
    }
    private void destroy()//su dung cho event tai sprite cuoi cung cua animation death
    {
        Destroy(gameObject);
    }

    public void ShowDamage(float dmg)
    {
        GameObject floatingDamge = Instantiate(floatingText, transform.position, Quaternion.identity);
        floatingDamge.GetComponentInChildren<TextMesh>().text = dmg.ToString();
    }
}
