using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IconWeapon : MonoBehaviour
{
    public UnityEvent PickupAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveObject()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))

        {
            PickupAction.Invoke();
            Destroy(gameObject);
        }
    }
}
