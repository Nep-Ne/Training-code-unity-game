using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{

    public enum Direction//phai public cai nay thi moi co the public playerDirection !!
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
    public Direction playerDirection;
    State playerState;
    public float speed = 7f;
    private Animator animator;
    private PlayerStat playerstat;
    public GameObject ProjectilePrefab;
    public Sprite Imageweapon;
    public GameObject weapon;
    public float force = 10000f;
    Rigidbody2D rb;
    float horizontal;
    float vertical ;
    public RuntimeAnimatorController controller;
    private GameObject PlayerLightFOV;
    private GameObject PlayerLightAround;
    

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
        PlayerLightAround = GameObject.FindGameObjectWithTag("PlayerLightAround");
        PlayerLightFOV = GameObject.FindGameObjectWithTag("PlayerLightFOV");
    }

    // Update is called once per frame
    void Update()
    {
        //action

        //Transformation to RobotGreen animation !!
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.runtimeAnimatorController = controller;
        }
        if (Input.GetMouseButtonDown(1))
        {

            //ThrowProjectile(new Vector2(1,0));
            weapon.GetComponent<SpriteRenderer>().sprite = Imageweapon;
            MeleeAttack();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
        //


        //Direction
        DirectionController();

        //state
        StateController();


        //Update direction for animation Move,Idle
        AnimationDirectionController();
    }
    void FixedUpdate()
    {

        ActionController(playerState);



    }
    void DirectionController()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //define direction Player
        if (vertical > 0 && (Mathf.Abs(vertical) >= Mathf.Abs(horizontal)))
        {
            playerDirection = Direction.Up;
            LightController(Direction.Up);
            PistolDirection(playerDirection);
        }

        else if (vertical < 0 && (Mathf.Abs(vertical) >= Mathf.Abs(horizontal)))
        {
            playerDirection = Direction.Down;
            LightController(Direction.Down);
            PistolDirection(playerDirection);
        }

        else if (horizontal > 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
        {
            playerDirection = Direction.Right;
            LightController(Direction.Right);
            PistolDirection(playerDirection);
        }

        else if (horizontal < 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
        {
            playerDirection = Direction.Left;
            LightController(Direction.Left);
            PistolDirection(playerDirection);
        }
        else if (horizontal == 0 && vertical == 0)
        {
            playerDirection = playerDirection;
        }
    }

    void StateController()
    {
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
    }

    void ActionController(State statePlayer)
    {
        if (statePlayer == State.Move)
        {
            MoveController();
        }
        else if (statePlayer == State.Idle)
        {
            IdleController();
        }
        else if(statePlayer == State.Death)
        {
            DeathAnimation();
            GameObject.Find("GameManager").GetComponent<GameOverMenu>().ActiveGameOver();
            rb.velocity = new Vector2(0, 0);
            
        }
    }

    void MoveController()
    {
        rb.velocity = new Vector2(horizontal, vertical) * speed;
        animator.SetBool("Moving", true);
    }

    void IdleController()
    {
        rb.velocity = new Vector2(0, 0);
        animator.SetBool("Moving", false);
    }

    void LightController(Direction direction)
    {
        if(PlayerLightFOV !=null && PlayerLightAround !=null)
        {
            switch (direction)
            {
                case Direction.Left:
                    PlayerLightAround.transform.eulerAngles = Vector3.forward * 270;
                    PlayerLightFOV.transform.eulerAngles = Vector3.forward * 90;
                    break;
                case Direction.Right:
                    PlayerLightAround.transform.eulerAngles = Vector3.forward * 90;
                    PlayerLightFOV.transform.eulerAngles = Vector3.forward * 270;
                    break;
                case Direction.Up:
                    PlayerLightAround.transform.eulerAngles = Vector3.forward * 180;
                    PlayerLightFOV.transform.eulerAngles = Vector3.forward * 0;
                    break;
                case Direction.Down:
                    PlayerLightAround.transform.eulerAngles = Vector3.forward * 0;
                    PlayerLightFOV.transform.eulerAngles = Vector3.forward * 180;
                    break;
            }
        }
    }

    void AnimationDirectionController()
    {
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

    void MeleeAttack()
    {
        animator.SetTrigger("Attack");
    }

    void DeathAnimation()
    {
        animator.SetBool("Death", true);
    }
    void ThrowProjectile(Vector2 direction)
    {
        GameObject projectileObject = Instantiate(ProjectilePrefab, rb.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        Debug.Log(direction);
        projectile.Throw(direction, force);
    }
 
    void Shooting()
    {
        GameObject pistol = GameObject.FindGameObjectWithTag("Pistol");
        if (pistol != null)
        {
            pistol.GetComponent<PistolController>().Shoot();
        }
        
    }
    void PistolDirection(Direction playerdirection)
    {
        GameObject pistol = GameObject.FindGameObjectWithTag("Pistol");
        if(pistol!=null)
        {
            if (playerdirection == Direction.Right)
            {
                pistol.transform.position = new Vector2(transform.position.x + 0.74f, transform.position.y + 0.01f);
                pistol.GetComponent<SpriteRenderer>().flipY = false;
                //cai transform ben trong vector2 la transform cua Player !!!
                pistol.transform.eulerAngles = Vector3.forward * 0;

            }
            else if (playerdirection == Direction.Up)
            {
                pistol.transform.position = new Vector2(transform.position.x, transform.position.y + 0.74f);
                pistol.GetComponent<SpriteRenderer>().flipY = false;
                pistol.transform.eulerAngles = Vector3.forward * 90;


            }
            else if (playerdirection == Direction.Down)
            {
                pistol.transform.position = new Vector2(transform.position.x, transform.position.y - 0.74f);
                pistol.GetComponent<SpriteRenderer>().flipY = false;
                pistol.transform.eulerAngles = Vector3.forward * 270;


            }
            else if (playerdirection == Direction.Left)
            {
                pistol.transform.position = new Vector2(transform.position.x - 0.74f, transform.position.y + 0.01f);
                pistol.transform.eulerAngles = Vector3.forward * 180;
                pistol.GetComponent<SpriteRenderer>().flipY = true;

            }
        }
        
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.collider.tag == "enemy")
    //    {
    //        animator.SetTrigger("GetHurt");
    //        playerstat.GetHurt(1);
    //    }
    //}
}
