using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Martin
{
    public class PlayerController : MonoBehaviour
    {

        private static PlayerController instance;
        public static PlayerController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType(typeof(PlayerController)) as PlayerController;
                    if (instance == null)
                    {
                        GameObject player = new GameObject();
                        player.AddComponent<PlayerController>();
                        instance = player.GetComponent<PlayerController>();
                    }
                }
                return instance;
            }
        }

        Animator anim;
        Rigidbody2D RB;
        CameraManager CM;

        enum AnimationType
        {
            IsGround,
            IsJump,
            IsHover
        };

        AnimationType animType;

        bool[] PlayerAnimSet; // 0 = ground, 1 = jump, 2 = hover
        bool isStop;
        Vector2 velocity;

        void Start()
        {
            anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            animType = AnimationType.IsGround;
            CM = FindObjectOfType(typeof(CameraManager)) as CameraManager;
            PlayerAnimSet = new bool[3];
        }

        void Update()
        {
            switch (animType)
            {
                case AnimationType.IsGround:
                    AnimationBoolSet(0);
                    break;
                case AnimationType.IsJump:
                    break;
                case AnimationType.IsHover:
                    AnimationBoolSet(2);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Space)/* && CM != null && CM.isInGame*/)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                isStop = !isStop;
                RB.velocity = velocity;
            }

            // only activate in ingame scene
            if (!isStop)
            {
                anim.speed = 1;
                RB.gravityScale = 1;
                velocity = RB.velocity;
            }
            else
            {
                anim.speed = 0;
                RB.velocity = Vector2.zero;
                RB.gravityScale = 0;
            }

            AnimationSetting();
        }

        void AnimationBoolSet(int idx)
        {
            for (int i = 0; i < PlayerAnimSet.Length; i++)
            {
                PlayerAnimSet[i] = false;
            }
            PlayerAnimSet[idx] = true;
        }

        void AnimationSetting()
        {
            anim.SetBool("IsGround", PlayerAnimSet[0]);
            anim.SetBool("IsJump", PlayerAnimSet[1]);
            anim.SetBool("IsHover", PlayerAnimSet[2]);
        }

        public void Hover()
        {
            Debug.Log("hover!");
            animType = AnimationType.IsHover;
        }

        public void Jump()
        {
            if (PlayerAnimSet[0])
            {
                animType = AnimationType.IsJump;
                AnimationBoolSet(1);
                RB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }

        public void Ground()
        {
            animType = AnimationType.IsGround;
            AnimationBoolSet(0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                Ground();
            }
        }
    }
}
