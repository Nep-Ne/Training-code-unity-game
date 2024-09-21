using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    float horizontal;
    float vertical;
    Rigidbody2D rg2d;
     float hp = 3;
    float period = 0.1f;
    string status="normal";
    // Start is called before the first frame update
    void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(1))
        {
            parry();
            Debug.Log("Pressed right click.");
            rg2d.velocity = new Vector2(7f, 7f);
        }
        //if(cd )
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + 7f * horizontal * Time.deltaTime;
        pos.y = pos.y + 7f * vertical * Time.deltaTime;
        rg2d.MovePosition(pos);
        Debug.Log("Velocity" + rg2d.velocity.ToString());
        rg2d.velocity = new Vector2(7f, 7f);
    }
    public bool IsAvailable = true;
    public float CooldownDuration = 1f;

    void parry()
    {
        // if not available to use (still cooling down) just exit
        if (IsAvailable == false)
        {
            return;
        }

        // made it here then ability is available to use...
        // UseAbilityCode goes here
        Debug.Log("Parry!!!.");

        // start the cooldown timer
        StartCoroutine(StartCooldown());
    }

    private void OnCollisionEnter2D(Collision2D other) //colision chứ không phải collider
    {
        if (IsAvailable==false)
        { 
            Debug.Log("ok"); 
        }
        else if(hp>0)
        {
            hp = hp - 1;
            Debug.Log("HP:"+hp.ToString());
        }
        else
        {
            Debug.Log("Died");
        }


    }


    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(CooldownDuration);
        //Debug.Log(Time.time);
        IsAvailable = true;
    }

}
