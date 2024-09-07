using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }
    enum State
    {
        Idle,
        Move,
        Hurt,
        Death
    }
    Direction playerDirection;
    State playerState;
    public float speed = 7f;
    private Animator animator;
    private PlayerStat playerstat;
    public GameObject ProjectilePrefab;
    public Sprite Imageweapon;
    public GameObject weapon;
    public float force = 10f;
    Rigidbody2D rb;
    float horizontal;
    float vertical ;
    // Start is called before the first frame update
    void Start()
    {
       playerDirection= Direction.Down;
        animator = GetComponent<Animator>();
        playerstat = GetComponent<PlayerStat>();
        rb = GetComponent<Rigidbody2D>();
        //them vao trang thai ban dau, neu thieu cai nay thi cai blendtree cua melee attack se o vi tri (0,0) va 
        //vi tri nay rat khac thuong !!!!!!!
        animator.SetFloat("MoveY", -1);
        animator.SetFloat("MoveX", 0);
        Debug.Log("Player transform:"+transform.position);
        Debug.Log("Player localtransform:" + transform.localPosition);
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
        //moveControl
        rb = GetComponent<Rigidbody2D>();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //define direction Player
        if (vertical > 0 && (Mathf.Abs(vertical) >= Mathf.Abs(horizontal)))// se khong smooth Li do: neu nhu cai abs(horizontal) dang > abs(vertical) va horizontal ==1 la direction dang la left
            //roi den khi vertical==1 tu nhien no khung lai doi sang huong len tren do dau "=" !!!
            //toi khong biet fix cai trai nghiem nguoi dung nay lam sao ca =((
            playerDirection = Direction.Up;
        else if (vertical < 0 && (Mathf.Abs(vertical) >= Mathf.Abs(horizontal)))
            playerDirection = Direction.Down;
        else if (horizontal > 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
            playerDirection = Direction.Right;
        else if (horizontal < 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
            playerDirection = Direction.Left;
        else if (horizontal == 0 && vertical == 0)
            playerDirection = playerDirection;//neu nhu khong di chuyen thi lay direction truoc do !!!

        //define state
        if ((horizontal != 0 || vertical != 0) && playerstat.HP > 0)
        {
            playerState = State.Move;
        }
        else if ((horizontal == 0 && vertical == 0) && playerstat.HP > 0)
        {
            playerState = State.Idle;
        }
        else if (playerstat.HP <= 0)
        {
            playerState = State.Death;
        }

        //Update direction for animation Move,Idle
        switch (playerDirection)
        {
            case Direction.Left:
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", 0);
                break;
            case Direction.Right:
                animator.SetFloat("MoveX", 1);
                animator.SetFloat("MoveY", 0);
                break;
            case Direction.Up:
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 1);
                break;
            case Direction.Down:
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
                break;
        }
    }
    void FixedUpdate()
    {
        
        if (playerState == State.Move)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed;
            animator.SetBool("Moving", true);
        }
        else if (playerState == State.Idle)
        {
            rb.velocity = new Vector2(0, 0);
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
