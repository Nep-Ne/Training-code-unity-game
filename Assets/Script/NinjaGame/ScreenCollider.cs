using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    private void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        CreateEdgeCollider();
    }
    void CreateEdgeCollider()
    {//fix loi neu player o vi tri khac (0,0) thi collision bi lech cho khac la them "- Camera.main.transform.position"
     //trong phan edges.Add trong moi toa do cua Edge!!!
        List<Vector2> edges = new List<Vector2>();
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero)- Camera.main.transform.position);
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)) - Camera.main.transform.position);
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - Camera.main.transform.position);
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2( 0,Screen.height)) - Camera.main.transform.position);
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero) - Camera.main.transform.position);
        edgeCollider.SetPoints(edges);
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
