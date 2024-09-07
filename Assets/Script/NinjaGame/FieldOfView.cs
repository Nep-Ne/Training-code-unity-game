using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float viewDistance = 5f;
    [Range(0, 360)]
    public float FOV_Angle=90f;
    [SerializeField]
    private int rayAmount = 2;//so luong field chia nho nghia la 1 field lon 90 do chia lam 2 field nho 45 do
    //private int rayAmount = 50;
    [SerializeField]
    private float startAngle = 0;
    private float angleIncrease;//ko hieu tai sao khong duoc private float angleIncrease=FOV_Angle / rayAmount; tai day luon !!
    private Vector3 startPoint ;
    Mesh mesh;
   //private Renderer myRenderer; //cai nay dung de order lai cach hien thi cho MeshRenderer !!!
    void Start()
    {
        startPoint = transform.localPosition;
        // startPoint = transform.position; se khong dung vi tri !!!
        //vi FOV la child object nen khi tao 1 mot component co su dung toa do thi no deu dung tren local space(khong gian parent) 
        //chu khong con dung tren global space nua !!!

        Debug.Log("transform:"+transform.position);
        Debug.Log("localtransform:" + transform.localPosition);
        Debug.Log("startPoint:" + startPoint);
        GameObject a = GameObject.Find("FOV");
        Debug.Log("FOV transform:"+a.GetComponent<Transform>().position);
        Debug.Log("parent of FOV:" + a.transform.parent);
        a.transform.parent = GameObject.Find("TheBoy").transform;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 0;
        angleIncrease = FOV_Angle / rayAmount;//angleIncrease nhu la goc cua moi phan trong FOV_Angle sau khi chia lam rayAmount lan!!
        Vector3[] vertices = new Vector3[rayAmount + 1 + 1];
        int[] triangles = new int[rayAmount * 3];
        Vector2[] uv = new Vector2[vertices.Length];
        vertices[0] = startPoint;
        
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayAmount; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Ultilis.AngleToVector(angle), viewDistance, layerMask);
            if (hit.collider != null)
            {
                vertex = (Vector3)(hit.point) - transform.position;
                vertex.z = transform.position.z;
            }
            else
            {
                vertex = Ultilis.AngleToVector(angle) * viewDistance;
                vertex.z = transform.position.z;
            }
            vertices[vertexIndex]= vertex;
            if (i>0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
    }

    private void LateUpdate()
    {
        //myRenderer.sortingOrder = 24;
    }
}
