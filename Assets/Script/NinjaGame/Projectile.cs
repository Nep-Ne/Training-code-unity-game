using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float MoveSpeed = 5.0f;
	//bo doan nay vi prefab khong cho reference den gameobject cua scene !!
	//public GameObject user;
	string TagUser;
	Rigidbody2D rb;
	Collider2D collider;
	void Awake()
	{
		//cai nay dung cho awake chu ko duoc dung cho start, vi ben PlayerController se goi den script nay ma script nay chua enable thi lam sao
		//lay gia tri rb !! Awake se thuc hien ke ca script nay ko duoc enable trong Player vi player can script nay lam gi!!!
		//awake dung cho ca script ma gameobject muon su dung cac bien khoi tao script do ke ca khi script do ko phai la component cua gameobject do!!
		rb = GetComponent<Rigidbody2D>();


		//tuy tag user minh muon chon
		GameObject user = GameObject.FindGameObjectWithTag("Player");
		TagUser = user.GetComponent<Collider2D>().tag;
		collider = GetComponent<Collider2D>();
		//Physics2D.IgnoreLayerCollision(gameObject.layer, user.layer);
	}

	void Update()
	{
		//bay theo do thi hinh sin
		//pos += transform.up * Time.deltaTime * MoveSpeed;
		//transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	public void Throw(Vector2 direction, float force)
	{
		//phai co normalized vi ko co thi neu truong hop direction la vector2(0.001,0.04) thi Force rat yeu, viec normalize khien cho 
		//direction tu co do lon bang 1
		rb.AddForce(direction.normalized * force);

	}

	//su dung Physics2D.IgnoreCollision
	void OnEnable()
	{
		GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject obj in otherObjects)
		{
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //cai GetComponent<Collider2D>() o phia sau <=> gameObject.GetComponent<Collider2D>())
        }
    }

	private void OnCollisionEnter2D(Collision2D other)
	{

		if (!other.collider.CompareTag(TagUser))
		{
			Destroy(gameObject);
			if (other.collider.CompareTag("enemy"))
			{

				Destroy(gameObject);
				other.gameObject.GetComponent<EnemyController>().Death();

			}
		}

		else

		{

            //Physics2D.IgnoreCollision(collider, other.collider);
            //ko bi con bi block lai nhung van khi va cham van gay force len nhau !!! Li do cai event OnCollisionEnter2D duoc thuc hien
            //cham hon !!! The nen khi dung Physics2D.IgnoreCollision thi ta nen goi no trong OnEnable() duoc su dung phia tren !!!


            //Physics2D.IgnoreLayerCollision(gameObject.layer, user.layer); thi moi co the ignore luon ca cai force, no chinh la
            //cai thay doi Matrix collision trong Project Setting!!!!
        }
    }

	//public float Damage()
	//{ 
	//	return 
	//}
}


