using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed= 6f;
    private Animator animator;
    private PlayerStat playerstat;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerstat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //moveControl
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed ;
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", vertical);
            animator.SetBool("Moving", true);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("Moving", false);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag=="enemy")
        {
            animator.SetTrigger("GetHurt");
            playerstat.GetHurt(1);
        }
    }
}
