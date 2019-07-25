﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer renderer;
    float velocity=1f,jumpForce=7f;
    public bool ground;
    private bool right;
    /*public Transform groundcheck;
    public LayerMask suelo;
    public float radiogrounded;
    public bool left;*/
    //public int fuerzaretro;
    //public bool salto;
    Animator anim;


    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ground = true;
        right = true;
    }

 
    void Update()
    {
        /*if (ground==false)
        {
            rb.velocity -= new Vector2(0f, 1f * Time.timeScale);
        }*/

        if (Input.GetKey(KeyCode.A) && ground)
        {
            if (rb.velocity.x > -4)
            {
                rb.velocity -= new Vector2(velocity * Time.timeScale, 0f);
            }

            if (anim.GetBool("Idle") == true)
            {
                anim.SetBool("Idle", false);
            }

            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
            renderer.flipX = true;
            right = false;
        }

        if (Input.GetKey(KeyCode.D) && ground)
        {
            if (rb.velocity.x < 4)
            {
                rb.velocity += new Vector2(velocity * Time.timeScale, 0f);
            }

            if (anim.GetBool("Idle") == true)
            {
                anim.SetBool("Idle", false);
            }

            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
            renderer.flipX = false;
            right = true;
        }

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            if (right)
            {
                rb.velocity = new Vector2(4f, jumpForce * Time.timeScale);
            }
            else
            {
                rb.velocity = new Vector2(-4f, jumpForce * Time.timeScale);
            }
            anim.Play("Jump");
            //anim.SetTrigger("Jump");
            ground = false;            
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && ground)
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        if (rb.velocity.magnitude == 0)
        {           
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }
    }

    /*private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, radiogrounded, suelo);

        if (salto)
        {
            rb.AddForce(new Vector2(0, fsalto), ForceMode2D.Impulse);
            salto = false;
        }
    }*/
}