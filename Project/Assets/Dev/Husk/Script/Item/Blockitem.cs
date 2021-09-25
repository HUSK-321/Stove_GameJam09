using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockitem : MonoBehaviour
{
    [SerializeField] GameObject TimelineBlock;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            print("아이고난1");
            TimelineBlock.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
