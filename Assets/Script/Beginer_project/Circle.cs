using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Rigidbody2D circle1;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        circle1=gameObject.GetComponent<Rigidbody2D>();
        circle1.AddForce(new Vector2(0,-1) *6 , ForceMode2D.Impulse);
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(circle1.sharedMaterial.bounciness ==1)
            {
                circle1.sharedMaterial.bounciness = 0;
                collider.enabled = false;
                collider.enabled = true;
                Debug.Log("bounciness=0");
            }
            else if (circle1.sharedMaterial.bounciness == 0)
            {
                circle1.sharedMaterial.bounciness = 1;
                collider.enabled = false;
                collider.enabled = true;
                Debug.Log("bounciness=1");
            }
            Debug.Log("Space!!");

        }
    }
}
