using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireWizard : MonoBehaviour
{
    [ColorUsage(true,true)]//2 dong nay phai dung ke nhau !!!
    [SerializeField] Color FlashColor;
    float HP=10f;
    public bool IsDeath;
    GameObject player;
    IEnumerator couroutine;
    private Material material;
    [SerializeField] float Flashamount;
    //public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        material=GetComponent<SpriteRenderer>().material;
        player = GameObject.Find("TheBoy");
        IsDeath = false;
        couroutine = Action(player.GetComponent<Transform>());
        StartCoroutine(couroutine);
    }

    // Update is called once per frame
    void Update()
    {
        //co the dung cach kiem tra va thuc hien Death ngay ben trong Hurt() !!!
        if(HP<=0)
        {
            StopCoroutine(couroutine);
            Death();
            Debug.Log("Death");
        }
    }

    IEnumerator Action(Transform PlayerTrans)
    {
        while (HP>0)
        {
            yield return new WaitForSeconds(1f);
            Move(PlayerTrans);
            yield return new WaitForSeconds(1f);
            Attack(PlayerTrans);
            
        }
        
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
        //if (HP <= 0)
        //{
        //    Death();
        //    StopCoroutine(couroutine);
        //}
        StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        material.SetColor("_FlashColor", FlashColor);
        material.SetFloat("_FlashAmount", Flashamount);
        yield return new WaitForSeconds(0.2f);
        material.SetFloat("_FlashAmount", 0);
    }

    public void Death()
    {
        IsDeath = true;
        GetComponent<Animator>().SetTrigger("Death");//loop time cua animation clip phai tat !!!
        //GetComponent<Animator>().SetBool("Death",true);
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;//tat cai script nay !!
        //Cai nay co cung duoc, khong cung duoc nhung tuong minh thi nen co ,dam bao rang cai script khong hoat dong va
        //cai upadate() cua no khong hoat dong nua !!!
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
