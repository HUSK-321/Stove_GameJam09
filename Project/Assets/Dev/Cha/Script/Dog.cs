﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float jumpHeight;
    
    private float TimeLeft = 3.0f;
    private float JumpTime = 0.0f;
    private float nextTime = 0.0f;
    Animator anim;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTime){
            nextTime = Time.time + TimeLeft;
            JumpTime = Time.time;
            anim.SetInteger("Jumping", 1);
            rigid.AddForce(new Vector3(0, jumpHeight,0), ForceMode2D.Impulse);
        }
        if(Time.time - JumpTime > 1.0f)
        {
            anim.SetInteger("Jumping", 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("아얏");
        }
    }
}
