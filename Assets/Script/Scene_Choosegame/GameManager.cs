using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
class BlockStory
{
    public string BlockMainStory;
    public string textoption1;
    public string textoption2;
    public BlockStory Blockoption1;
    public BlockStory Blockoption2;

    public BlockStory(string BlockMainStory, string textoption1 = "", string textoption2 = "", BlockStory Blockoption1 = null, BlockStory Blockoption2 =null)
    {
        this.BlockMainStory =  BlockMainStory;
        this.textoption1 = textoption1;
        this.textoption2 = textoption2;
        this.Blockoption1 = Blockoption1;
        this.Blockoption2 = Blockoption2;
    }

}



public class GameManager : MonoBehaviour
{
    public TMP_Text mainstory;
    public Button btoption1;
    public Button btoption2;
    static BlockStory BlockStory4 = new BlockStory("you wake up from dream");
    static BlockStory BlockStory2 = new BlockStory("She kill you. Game over");
    static BlockStory BlockStory3 = new BlockStory("you find out red door and blue door", "red door", "blue door", BlockStory4);
    static BlockStory BlockStory1 = new BlockStory("You wake up, you see a girl is sleep to you. What would you do ?","Wake her up","ignore her", BlockStory2, BlockStory3);
    BlockStory currentBlock = BlockStory1;
    // Start is called before the first frame update
    void Start()
    {
        mainstory.text = currentBlock.BlockMainStory;
        btoption1.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption1;
        btoption2.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption2;
        Debug.Log(currentBlock.Blockoption1);
    }


    public void ClickBT1()
    {
        currentBlock = currentBlock.Blockoption1;
        mainstory.text = currentBlock.BlockMainStory;
        btoption1.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption1;
        btoption2.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption2;
    }
    public void ClickBT2()
    {
        currentBlock = currentBlock.Blockoption2;
        mainstory.text = currentBlock.BlockMainStory;
        btoption1.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption1;
        btoption2.GetComponentInChildren<TMP_Text>().text = currentBlock.textoption2;
    }
}
