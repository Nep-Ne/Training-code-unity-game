using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D circle1=gameObject.GetComponent<Rigidbody2D>();
        circle1.AddForce(new Vector2(0,-1) *6 , ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
