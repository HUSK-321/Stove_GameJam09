using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField] ParticleSystem particle;

        enum AnimationType
        {
            IsGround,
            IsJump,
            IsHover,
            IsInvincible,
            IsIdle
        };

        AnimationType animType;

        bool[] PlayerAnimSet; // 0 = ground, 1 = jump, 2 = hover, 3 = invincible, 4 = idle
        bool jumpAble;
        bool isStop;
        Vector2 velocity;

        //JumpForce
        public float jumpForce;

        void Start()
        {
            CM = FindObjectOfType(typeof(CameraManager)) as CameraManager;
            anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            PlayerAnimSet = new bool[5];
            animType = AnimationType.IsIdle;
            AnimationBoolSet((int)animType);
            jumpAble = true;
            particle.Stop();
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
                case AnimationType.IsInvincible:
                    AnimationBoolSet(3);
                    break;
                case AnimationType.IsIdle:
                    AnimationBoolSet(4);
                    break;
            }

            //if (Input.GetKeyDown(KeyCode.Space)/*&& CM.isInGame*/)
            //{
            //    Jump();
            //}
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    isStop = !isStop;
            //    RB.velocity = velocity;
            //}
            //if (Input.GetKeyDown(KeyCode.I))
            //{
            //    Invincible();
            //}

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

            //UnityEditor.EditorApplication.isPaused = true;
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
            anim.SetBool("IsInvincible", PlayerAnimSet[3]);
            anim.SetBool("IsIdle", PlayerAnimSet[4]);
        }

        public void Hover()
        {
            Debug.Log("hover!");
            animType = AnimationType.IsHover;
        }

        public void Jump(float jumpforceY = 0)
        {
            if (jumpforceY == 0) jumpforceY = jumpForce;

            if (PlayerAnimSet[0] || PlayerAnimSet[4] && jumpAble)
            {
                jumpAble = false;
                animType = AnimationType.IsJump;
                AnimationBoolSet(1);
                RB.AddForce(new Vector2(0, jumpforceY), ForceMode2D.Impulse);
            }
            else if(PlayerAnimSet[3] && jumpAble)
            {
                jumpAble = false;
                RB.AddForce(new Vector2(0, jumpforceY), ForceMode2D.Impulse);
            }
            else if(PlayerAnimSet[1] || PlayerAnimSet[2] && jumpforceY != jumpForce)
            {
                RB.velocity = Vector2.zero;
                RB.AddForce(new Vector2(0, jumpforceY), ForceMode2D.Impulse);
            }
        }

        public void Ground()
        {
            animType = AnimationType.IsGround;
            jumpAble = true;
        }

        public void Invincible()
        {
            animType = AnimationType.IsInvincible;
        }

        public void GameOver()
        {
            StartCoroutine(GameOverEffect());
        }

        IEnumerator GameOverEffect()
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            particle.Play();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MoveHorizontal(int dir/*-1 = left, 1 = right*/)
        {
            Ground();
            transform.Translate(Vector3.right * dir * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground") && !PlayerAnimSet[3] && !PlayerAnimSet[4])
            {
                Ground();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Enemy") && !PlayerAnimSet[3])
            {
                GameOver();
            }
        }
    }
}
