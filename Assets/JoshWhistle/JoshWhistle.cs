using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JoshWhistle : MonoBehaviour//Giong script EnemyController nhung khac o cho bo animation !!!
{

    Transform Player;
    private Vector2 direction;
    private Rigidbody2D rb;
    public float health = 10f;
    public float maxhealth = 10f;
    [SerializeField] private GameObject floatingText;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (agent)
            agent.SetDestination(Player.position);
    }

    private void FixedUpdate()
    {
            Chase(Player);
    }

    void Chase(Transform target)
    {

        direction = new Vector2(agent.velocity.x, agent.velocity.y);
    }

    public void Death()
    {
        Debug.Log("Death");
        Destroy(gameObject.GetComponent<NavMeshAgent>());

        Destroy(gameObject.GetComponent<Collider2D>());


        Destroy(gameObject.GetComponent<Rigidbody2D>());


    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ShowDamage(dmg);
        if (health <= 0)
        {
            Death();
        }
    }
    private void destroy()
    {
        Destroy(gameObject);
    }

    public void ShowDamage(float dmg)
    {
        GameObject floatingDamge = Instantiate(floatingText, transform.position, Quaternion.identity);
        floatingDamge.GetComponentInChildren<TextMesh>().text = dmg.ToString();
    }
}
