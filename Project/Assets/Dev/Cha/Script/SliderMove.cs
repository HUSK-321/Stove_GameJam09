using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;
    RaycastHit[] hits;
    float MaxDistance = 15f;
    // Start is called before the first frame update
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
        
    }

    // Update is called once per frame
    void Update()
    {
        hits=Physics.RaycastAll(transform.position, Vector3.down, 100);

        for(int i = 0; i < hits.Length; i++){
            RaycastHit hit = hits[i];
            Debug.Log("인식");
        }
    }
}
