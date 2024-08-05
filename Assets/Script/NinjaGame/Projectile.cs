using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float MoveSpeed = 5.0f;
	public GameObject user;
	string TagUser;
	Rigidbody2D rb;
	Collider2D collider;
	//public GameObject user;
	void Awake()
	{
		//cai nay dung cho awake chu ko duoc dung cho start, vi ben PlayerController se goi den script nay ma script nay chua enable thi lam sao
		//lay gia tri rb !! Awake se thuc hien ke ca script nay ko duoc enable trong Player vi player can script nay lam gi!!!
		//awake dung cho ca script ma gameobject muon su dung cac bien khoi tao script do ke ca khi script do ko phai la component cua gameobject do!!
		rb = GetComponent<Rigidbody2D>();
		TagUser = user.GetComponent<Collider2D>().tag;
		collider = GetComponent<Collider2D>();
		Physics2D.IgnoreLayerCollision(gameObject.layer, user.layer);
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

	private void OnCollisionEnter2D(Collision2D other)
	{

		if (!other.collider.CompareTag(TagUser))
		{
			Destroy(gameObject);
		}

		else
		{

			//Physics2D.IgnoreCollision(collider, other.collider);
			//ko bi con bi block lai nhung van khi va cham van gay force len nhau !!!
			//Physics2D.IgnoreLayerCollision(gameObject.layer, user.layer); thi moi co the ignore luon ca cai force !!!
		}
	}
	//public float Damage()
	//{ 
	//	return 
	//}
}
