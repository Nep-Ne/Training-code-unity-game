using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractAble : MonoBehaviour
{
    [SerializeField] bool isInRange;
    public KeyCode InteractKey;
    public UnityEvent InteractAction;
    //public UnityEvent ExistInteraction;
    void Start()
    {
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(InteractKey))
            InteractAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
