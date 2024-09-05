using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7f;
    private Animator animator;
    private PlayerStat playerstat;
    public GameObject ProjectilePrefab;
    public Sprite Imageweapon;
    public GameObject weapon;
    //public Transform PointProjectile;
    public float force = 10f;
    //direction dung dung ThrowProjectile()
    //Vector2 direction;
    Rigidbody2D rb;
    float horizontal;
    float vertical ;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
        playerstat = GetComponent<PlayerStat>();
        rb = GetComponent<Rigidbody2D>();
        //them vao trang thai ban dau, neu thieu cai nay thi cai blendtree cua melee attack se o vi tri (0,0) va 
        //vi tri nay rat khac thuong !!!!!!!
        animator.SetFloat("MoveY", -1);
        animator.SetFloat("MoveX", 0);
        Debug.Log("Player transform:"+transform.position);
        Debug.Log("Player localtransform:" + transform.localPosition);
        //direction dung dung ThrowProjectile()
        //direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //ThrowProjectile(direction);
            weapon.GetComponent<SpriteRenderer>().sprite = Imageweapon;
            MeleeAttack();
        }

    }
    void FixedUpdate()
    {
        //moveControl
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if (horizontal != 0 || vertical != 0)
        {
            if(horizontal<0) animator.SetFloat("MoveX", -1);
            if(horizontal>0) animator.SetFloat("MoveX", 1);
            if(vertical>0) animator.SetFloat("MoveY", 1);
            if (vertical < 0) animator.SetFloat("MoveY", -1);
            if (horizontal == 0) animator.SetFloat("MoveX", 0);
            if (vertical ==0 ) animator.SetFloat("MoveY", 0);
            rb.velocity = new Vector2(horizontal, vertical) * speed;
            //animator.SetFloat("MoveX", horizontal);
            //animator.SetFloat("MoveY", vertical);

            //direction dung dung ThrowProjectile()
            //direction = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
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
    void MeleeAttack()
    {
        animator.SetTrigger("Attack");

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
            playerstat.GetHurt(1);
        }
    }
}
