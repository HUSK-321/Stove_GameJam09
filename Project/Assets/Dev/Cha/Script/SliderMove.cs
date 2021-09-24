using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;
    public Transform Target;
    public float Speed = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = new Vector2(-6.5f, -14.55f);
        endPos = new Vector2(8f, -14.55f);
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
        UpdateMove(startPos, endPos, 10f);
    }

    void UpdateMove(Vector2 startPos, Vector2 targetPos, float duration)
    {
        float timer = 0f;

        // 이동 시작 위치 설정
        Vector2 position = startPos;
        rectTransform.anchoredPosition = position;

        // 시간에 따른 위치 설정
        while (timer < duration)
        {
            timer += Time.deltaTime;

            position.x = Mathf.Lerp(startPos.x, targetPos.x, timer / duration);
            position.y = Mathf.Lerp(startPos.y, targetPos.y, timer / duration);

            rectTransform.anchoredPosition = position;
        }

        // 이동 종료 위치 설정
        position = targetPos;
        rectTransform.anchoredPosition = position;
    }
}
