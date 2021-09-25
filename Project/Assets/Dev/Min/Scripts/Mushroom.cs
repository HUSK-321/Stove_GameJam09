using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    [SerializeField] float jumpForce;
    BoxCollider2D boxCol;
    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Martin.PlayerController>().Jump(jumpForce);
        }
    }
}
