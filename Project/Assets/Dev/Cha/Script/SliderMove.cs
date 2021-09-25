using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    // -6.5 -14.55
    // 8
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;
    [SerializeField] CameraManager cameraManager;
    bool jumped;

    void Awake()
    {
        jumped = false;
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(cameraManager.isInGame)
        {
            RaycastHit2D rayHitR = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("R"));
            if(rayHitR.collider != null)
            {
                Martin.PlayerController.Instance.MoveHorizontal(1);
            }

            RaycastHit2D rayHitL = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("L"));
            if(rayHitL.collider != null)
            {
                Martin.PlayerController.Instance.MoveHorizontal(-1);
            }

            RaycastHit2D rayHitJ = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("J"));
            if(rayHitJ.collider != null)
            {
                if(!jumped)
                {
                    jumped = true;
                    Martin.PlayerController.Instance.Jump();
                }
            }
            else 
            {
                jumped = false;
            }

            RaycastHit2D rayHitI = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("I"));
            if(rayHitI.collider != null)
            {
                Martin.PlayerController.Instance.Invincible();
            }
            else 
            {
                Martin.PlayerController.Instance.Ground();
            }
        }
    }
    float currentTime = 0f;
    int count = 0;

    void Update()
    {
        if(cameraManager.isInGame)
        {
            StartMove();
            currentTime += Time.deltaTime;

            if(currentTime > 1)
            {
                count++;
                if(count == 10)
                    rigid.velocity = new Vector3(0, 0, 0);
                currentTime = 0f;
            }
        }
        else 
        {
            StopMove();
        }

    }


    #region 이동 관련


    void StartMove()
    {
        rigid.velocity = new Vector3(1.445f, 0f, 0f);

    }

    void StopMove()
    {
        rigid.velocity = new Vector3(0, 0, 0);
    }


    #endregion

}
