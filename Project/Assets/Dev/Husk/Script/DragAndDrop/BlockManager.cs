using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager instance;
    Queue<DragAndDrop> rightBlockQueue = new Queue<DragAndDrop>();
    Queue<DragAndDrop> leftBlockQueue = new Queue<DragAndDrop>();
    Queue<DragAndDrop> jumpBlockQueue = new Queue<DragAndDrop>();
    Queue<DragAndDrop> invincibleBlockQueue = new Queue<DragAndDrop>();
    public DragAndDrop[] prefabArr;

    private void Awake() 
    {
        instance = this;
        IntoQueue(1, 1, 5);
        IntoQueue(1, 1, 7);
        IntoQueue(1, 1, 10);
    }

    void IntoQueue(int qIndex, int blockIndex, int bolckSize)
    {
        switch(qIndex)
        {
            case 1:
                rightBlockQueue.Enqueue(CreateBlock(blockIndex, bolckSize));
                break;
            case 2:
                leftBlockQueue.Enqueue(CreateBlock(blockIndex, bolckSize));
                break;
            case 3:
                jumpBlockQueue.Enqueue(CreateBlock(blockIndex, bolckSize));
                break;
            case 4:
                invincibleBlockQueue.Enqueue(CreateBlock(blockIndex, bolckSize));
                break;
        }
    }

    DragAndDrop CreateBlock(int index, int sizeX)
    {
        DragAndDrop obj = Instantiate(prefabArr[index]);
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.localScale = new Vector3(sizeX, 5f, 1f);
        obj.transform.SetParent(transform);


        return obj;
    }
}
