using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    // -6.5 -14.55
    // 8
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        RaycastHit2D rayHitR = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("R"));
        if(rayHitR.collider != null)
        {
            Debug.Log("R");
        }

        RaycastHit2D rayHitL = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("L"));
        if(rayHitL.collider != null)
        {
            Debug.Log("L");
        }
        RaycastHit2D rayHitJ = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("J"));
        if(rayHitJ.collider != null)
        {
            Debug.Log("J");
        }
        RaycastHit2D rayHitI = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("I"));
            if(rayHitI.collider != null)
        {
            Debug.Log("I");
        }
    }
    void Start()
    {
        rigid.velocity = new Vector3(1.45f, 0f, 0f);
        print(transform.position);
    }
    float currentTime = 0f;
    int count = 0;

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > 1)
        {
            print(transform.position);
            count++;
            if(count == 10)
                rigid.velocity = new Vector3(0, 0, 0);
            currentTime = 0f;
        }
    }


}
