using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public Sprite TreasureOpenImg;
    public Sprite TreasureCloseImg;
    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = TreasureOpenImg;
    }
    public void Close()
    {
        GetComponent<SpriteRenderer>().sprite = TreasureOpenImg;
    }
}
