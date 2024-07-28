using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private PlayerStat playerstat;
    public GameObject ProjectilePrefab;
    //public Transform PointProjectile;
    public float force = 10f;
    Vector2 direction;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerstat = GetComponent<PlayerStat>();
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
            ThrowProjectile(direction);
        }

    }
    void FixedUpdate()
    {
        //moveControl
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed;
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", vertical);
            animator.SetBool("Moving", true);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            //bo dong code nay vao se ko giu lai huong cua nhan vat vi blendtree se cap nhat MoveX=0,MoveY=0 va ko giu trang thai cuoi cung => ko de
            //huong nhan vat o lan cuoi cung di chuyen !!!

            //animator.SetFloat("MoveX", horizontal);
            //animator.SetFloat("MoveY", vertical);


            animator.SetBool("Moving", false);
        }



    }

    void ThrowProjectile(Vector2 direction)
    {
        GameObject projectileObject = Instantiate(ProjectilePrefab, rb.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        Debug.Log(direction);
        projectile.Throw(direction, force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "enemy")
        {
            animator.SetTrigger("GetHurt");
            playerstat.GetHurt();
        }
    }
}
