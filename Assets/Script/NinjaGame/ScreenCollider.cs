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
    {
        List<Vector2> edges = new List<Vector2>();
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2( 0,Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edgeCollider.SetPoints(edges);
        //tao dung khi cai camera chinh o vi tri (0,0) !! neu dung camera follow player thi player ban dau phai o vi tri (0,0)
        //neu ban thu de camera theo doi nhan vat va nhan vat do ko co o vi tri (0,0) thi ban thay cai collider nay bi lech so voi goc nhin camera
        //hoac neu ban bo cai camera theo doi bang camera thuong va de no o vi tri ko phai la (0,0) thi cai collider cung bi lech !!!
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
