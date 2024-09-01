using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//neu bo dong nay va doi tat ca NavMeshAgent thanh UnityEngine.AI.NavMeshAgent thi bi loi !! Tai Sao??

public class EnemyController : MonoBehaviour
{
    
    Transform Player;
    //public Transform village;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;
    //public float speed = 4f;
    //speed da duoc su dung trong NevMeshAgent !!
    public float health = 10f;
    public float maxhealth = 10f;
    [SerializeField] private GameObject floatingText;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(agent)//kiem tra khac null vi khi death no se bi delete nghia la Null, neu khong xet truong hop NULL thi se bi loi NullReference !!
        agent.SetDestination(Player.position);
    }

    private void FixedUpdate()
    {
        if(animator.GetBool("Death")==false)
        Chase(Player);
    }

    void Chase(Transform target)
    {

        //float distance = Vector2.Distance(target.position, transform.position);
        //direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        //rb.velocity = direction.normalized* speed ;
        direction = new Vector2(agent.velocity.x, agent.velocity.y);
        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
        animator.SetBool("Moving", true);
    }

    public void Death()
    {
        animator.SetBool("Death", true);
        Debug.Log("Death");
        //xoa AI
        Destroy(gameObject.GetComponent<NavMeshAgent>());
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
