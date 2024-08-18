using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class SpawnEnemy : MonoBehaviour
{

    public float wavetime = 5f;
    public float timecd=0f;
    //public int amountEnemyWave = 3;
    //public int[] RangeX;
    //public int[] NotRangeX;//phan khong duoc spawn ben trong pham phi x !!
    //public int[] RangeY;
    //public int[] NotRangeY;//phan khong duoc spawn ben trong pham phi y !!
    public Transform[] spanwPosition;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timecd <= 0)
        {
            Spawn();
            timecd = wavetime;
        }
        else timecd -= Time.deltaTime;
    }
    void Spawn()
    {
        //Instantiate(enemy,new Vector3(RandomValueFromRanges(new Range(RangeX[0],NotRangeX[0]),new Range(RangeX[1],NotRangeX[1])), RandomValueFromRanges(new Range(RangeY[0], NotRangeY[0]), new Range(RangeY[1], NotRangeY[1])),0), Quaternion.identity);
        int randomIndex = Random.Range(0, spanwPosition.Length);
        Debug.Log("pos: " + randomIndex.ToString());
        Instantiate(enemy, spanwPosition[randomIndex].position, Quaternion.identity);
        
    }

    //public struct Range
    //{
    //    public int min;
    //    public int max;
    //    public int range { get { return max - min + 1; } }
    //    public Range(int aMin, int aMax)
    //    {
    //        min = aMin; max = aMax;
    //    }
    //}

    //public static int RandomValueFromRanges(params Range[] ranges)
    //{
    //    if (ranges.Length == 0)
    //        return 0;
    //    int count = 0;
    //    foreach (Range r in ranges)
    //        count += r.range;
    //    int sel = UnityEngine.Random.Range(0, count);
    //    foreach (Range r in ranges)
    //    {
    //        if (sel < r.range)
    //        {
    //            return r.min + sel;
    //        }
    //        sel -= r.range;
    //    }
    //    throw new Exception("This should never happen");
    //}
}
