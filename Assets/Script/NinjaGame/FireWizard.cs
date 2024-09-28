using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireWizard : MonoBehaviour
{
    float HP=30f;
    GameObject player;
    //public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("TheBoy");
        StartCoroutine(Action(player.GetComponent<Transform>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Action(Transform PlayerTrans)
    {
        while (HP>=0)
        {
            Move(PlayerTrans);
            yield return new WaitForSeconds(1f);
            Attack(PlayerTrans);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    private void Move(Transform PlayerTrans)
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Rigidbody2D>().position= PlayerTrans.position;

    }

    private void Attack(Transform PlayerTrans)
    {
        GetComponent<Animator>().SetBool("Attack", true);
        if (PlayerTrans.position.x < transform.position.x)//check if Player is left of fireWirzard
        {
            GetComponent<SpriteRenderer>().flipX = true;
            //Fire.GetComponent<Transform>().eulerAngles = Vector3.forward * 270;
            FindInActiveObject.FindInActiveObjectByName("Fire").GetComponent<Transform>().eulerAngles = Vector3.forward * 270;

            //GameObject.Find("Fire").GetComponent<Transform>().eulerAngles = Vector3.forward * 90; 
            //cai nay khong dung duoc mac du fire no duoc active trong animator !! Co le la do GameObject.Find("Fire")
            //chay qua nhanh truoc khi animtor kip active fire !!!
        }
        else 
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Fire.GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
            FindInActiveObject.FindInActiveObjectByName("Fire").GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
            //GameObject.Find("Fire").GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
        }

    }

    private void Hurt()
    {
        HP--;
        Debug.Log(HP);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Hurt();
        }
        
        
    }

}
