﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer renderer;
    //public float fsalto;
    public float velocidad=1;
    /*bool isGrounded;
    public Transform groundcheck;
    public LayerMask suelo;
    public float radiogrounded;
    public bool left;*/
    //public int fuerzaretro;
    //public bool salto;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //left = false;
        anim = GetComponent<Animator>();
        //salto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {            
            if (rb.velocity.magnitude < 4)
            {
                rb.velocity += new Vector2(-velocidad * Time.timeScale, 0f);
            }

            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
            renderer.flipX = true;
            
            /*if (!left)
            {
                left = true;
                facechange = true;
                Vector3 childScale = child.transform.localScale;
                childScale.x *= -1;
                child.transform.localScale = childScale;
                //print("girar left");
            }
            else
                facechange = false;*/

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.magnitude < 4)
            {
                rb.velocity += new Vector2(velocidad * Time.timeScale, 0f);
            }

            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
            renderer.flipX = false;

        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(0f, 0f);
            anim.SetBool("Walk", false);
        }

        /*else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector2(velocidad, 0f);




            if (anim.GetBool("Movimiento") == false)
            {
                anim.SetBool("Movimiento", true);
            }

            if (left)
            {
                left = false;
                facechange = true;
                //print("girar right");
                Vector3 childScale = child.transform.localScale;
                childScale.x *= -1;
                child.transform.localScale = childScale;
            }

            else
                facechange = false;
        }*/

        /*else if (!Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D) && (rb.velocity.x <= 4f * velocidad) && (rb.velocity.x >= -4f * velocidad)))
        {
            anim.SetBool("Movimiento", false);
        }*/

        /*if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            salto = true;
        }*/

        /*if (facechange)
        {
            transform.Rotate(0f, 180f, 0f);
            facechange = false;
        }*/


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

    /*public void Retroceso()
    {
        rb.AddForce(transform.right * -fuerzaretro);
    }*/
}