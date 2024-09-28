using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameObject pistol = GameObject.Find("Pistol") ;
            GameObject weapon = FindInActiveObject.FindInActiveObjectByName("weapon");//FindInActiveObject la class custom
            //trong file FindInActiveObject.cs
            if (pistol!=null)
            {
                Debug.Log("pistol have enabled");
                
            }
            else Debug.Log("pistol still disabled");

            if (weapon.GetComponent<SpriteRenderer>().enabled)
            {
                Debug.Log("You have enable SpriteRenderer melee weapon!!");
            }
            else Debug.Log("You don't have enable SpriteRenderer melee weapon!!");

            if (pistol != null && weapon.GetComponent<SpriteRenderer>().enabled)
                SceneManager.LoadScene(sceneName);
            else return;
        }
    }
}
