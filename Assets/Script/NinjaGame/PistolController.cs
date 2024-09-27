using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    bool isAbleShoot;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float force=2000f;
    Transform SpawnBullet;
    // Start is called before the first frame update
    void Start()
    {
        isAbleShoot = true;
        SpawnBullet = GameObject.Find("SpawnBullet").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject BulletObject = Instantiate(BulletPrefab, SpawnBullet.position, Quaternion.identity);
        Rigidbody2D rbBullet = BulletObject.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.right * force);
        //rbBullet.AddForce(Vector2.right * force);
    }
}
