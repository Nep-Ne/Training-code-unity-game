using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


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
    PlayerController playerController;
    Mesh mesh;

    //Phuong phap Update thay vi su dung event !!!!
    //PlayerController.Direction playerDirection;
    void Start()
    {
        startPoint = transform.localPosition;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //dung cho event !!!
        playerController = transform.parent.GetComponent<PlayerController>();
        //playerController.EventPlayerChangeDirection += CreateFOV;

    }

    // Update is called once per frame
    void Update()
    {
        //Phuong phap Update thay vi su dung event !!!!

        //playerDirection = transform.parent.GetComponent<PlayerController>().playerDirection;
        //RotateFOV(playerDirection);
        //float angle = startAngle;
        //angleIncrease = FOV_Angle / rayAmount;//angleIncrease nhu la goc cua moi phan trong FOV_Angle sau khi chia lam rayAmount lan!!
        //Vector3[] vertices = new Vector3[rayAmount + 1 + 1];
        //int[] triangles = new int[rayAmount * 3];
        //Vector2[] uv = new Vector2[vertices.Length];
        //vertices[0] = startPoint;


        //int vertexIndex = 1;
        //int triangleIndex = 0;
        //for (int i = 0; i <= rayAmount; i++)
        //{
        //    Vector3 vertex;
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Ultilis.AngleToVector(angle), viewDistance, layerMask);
        //    if (hit.collider != null)
        //    {
        //        vertex = (Vector3)(hit.point) - transform.position;
        //        vertex.z = transform.position.z;
        //    }
        //    else
        //    {
        //        vertex = Ultilis.AngleToVector(angle) * viewDistance;
        //        vertex.z = transform.position.z;
        //    }
        //    vertices[vertexIndex] = vertex;
        //    if (i > 0)
        //    {
        //        triangles[triangleIndex + 0] = 0;
        //        triangles[triangleIndex + 1] = vertexIndex - 1;
        //        triangles[triangleIndex + 2] = vertexIndex;
        //        triangleIndex += 3;
        //    }
        //    vertexIndex++;
        //    angle -= angleIncrease;
        //}

        //mesh.vertices = vertices;
        //mesh.triangles = triangles;
        //mesh.uv = uv;

    }

    private void LateUpdate()
    {
        //myRenderer.sortingOrder = 24;
    }


    //Phuong phap update thay vi dung event
    //private void RotateFOV(PlayerController.Direction direction)
    //{
    //    switch (direction)
    //    {
    //        case PlayerController.Direction.Left:
    //            startAngle = FOV_Angle / 2 + 180;
    //            break;
    //        case PlayerController.Direction.Right:
    //            startAngle = FOV_Angle / 2;
    //            break;
    //        case PlayerController.Direction.Up:
    //            startAngle = FOV_Angle / 2 + 90;
    //            break;
    //        case PlayerController.Direction.Down:
    //            startAngle = FOV_Angle / 2 + 270;
    //            break;

    //    }
    //}


    //Day la phuong phap dung event, su dung cach Update lien tuc tren Gameobject FOV van duoc nhung toi van su dung event vi de luyen code !!!
    private void CreateFOV(PlayerController.Direction direction)
    {
        switch (direction)
        {
            case PlayerController.Direction.Left:
                startAngle = FOV_Angle / 2 + 180;
                break;
            case PlayerController.Direction.Right:
                startAngle = FOV_Angle / 2;
                break;
            case PlayerController.Direction.Up:
                startAngle = FOV_Angle / 2 + 90;
                break;
            case PlayerController.Direction.Down:
                startAngle = FOV_Angle / 2 + 270;
                break;

        }
        float angle = startAngle;
        angleIncrease = FOV_Angle / rayAmount;
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
            vertices[vertexIndex] = vertex;
            if (i > 0)
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

}
