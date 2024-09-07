using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartSystem : MonoBehaviour
{

    public PlayerStat stat;
    private float amountHeart;//so heart tuong ung maxhp
    private int typeComplexHeart;//1 heart le
    private float amountFullHeart;//so luong fullheart
    public Image[] hearts;//gioi han so luong heart trong 1 game
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite threeQuarterHeart;
    // Start is called before the first frame update
    void Start()
    {
        ConvertHPtoHeart(stat.maxHP, stat.HP);
        SetHeart(amountHeart, typeComplexHeart);
        //Debug.Log(amountFullHeart);

    }

    // Update is called once per frame
    void Update()
    {
        ConvertHPtoHeart(stat.maxHP, stat.HP);
        SetHeart(amountHeart, typeComplexHeart);
    }

    void ConvertHPtoHeart(float maxHP,float hp)
    {
        if (stat.HP > stat.maxHP) stat.HP = stat.maxHP;//dam bao current hp khong bao gio vuot qua maxhp
        amountHeart = maxHP / 4;
        switch (hp % 4)
        {
            case 0:
                typeComplexHeart = 0;
                break;
            case 1:
                typeComplexHeart = 1;
                break;
            case 2:
                typeComplexHeart = 2;
                break;
            case 3:
                typeComplexHeart = 3;
                break;
        }
        amountFullHeart = Mathf.Floor(hp / 4);
    }
    void SetHeart(float amountHeart, int typeComplexHeart)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < amountHeart)
            {
                hearts[i].enabled = true;
                if(i<amountFullHeart)
                {  
                    hearts[i].sprite = fullHeart;
                }
                 else if (i == amountFullHeart)//vi tri cho heart le
                {
                    hearts[i].enabled = true;
                    switch (typeComplexHeart)
                    {
                        case 0:
                            hearts[i].sprite = emptyHeart;
                            break;
                        case 1:
                            hearts[i].sprite = quarterHeart;
                            break;
                        case 2:
                            hearts[i].sprite = halfHeart;
                            break;
                        case 3:
                            hearts[i].sprite = threeQuarterHeart;
                            break;

                    }
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            
           
            }
            else hearts[i].enabled = false;
        }
    }
}
