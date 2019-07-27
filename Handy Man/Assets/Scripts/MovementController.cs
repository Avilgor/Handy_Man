using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer renderer;
    float velocity=1f,jumpForce=7f;
    public bool ground;
    private bool move;
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
        move = true;
    }

 
    void Update()
    {
        /*if (ground==false)
        {
            rb.velocity -= new Vector2(0f, 1f * Time.timeScale);
        }*/

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && ground)
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        else if (Input.GetKey(KeyCode.A) && ground && move && !Input.GetKey(KeyCode.D))
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
        }

        else if (Input.GetKey(KeyCode.D) && ground && move && !Input.GetKey(KeyCode.A))
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
        }



        else if (Input.GetKey(KeyCode.D) && !ground && move)
        {
            if (rb.velocity.x < 4)
            {
                rb.velocity += new Vector2(velocity * Time.timeScale, 0f);
            }
            renderer.flipX = false;
        }

        else if (Input.GetKey(KeyCode.A) && !ground && move)
        {
            if (rb.velocity.x > -4)
            {
                rb.velocity -= new Vector2(velocity * Time.timeScale, 0f);
            }
            renderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            rb.AddForce(new Vector2(0f, jumpForce * Time.timeScale),ForceMode2D.Impulse);
            anim.Play("Jump");
            ground = false;            
        }


        if (rb.velocity.magnitude == 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && ground)
        {           
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.E) && ground)
        {
            rb.velocity = new Vector2(0f, 0f);
            move = false;

            if (anim.GetBool("Idle") == true)
            {
                anim.SetBool("Idle", false);
            }

            if (anim.GetBool("Walk") == true)
            {
                anim.SetBool("Walk", false);
            }
            //anim.StopPlayback();
            //anim.Play("Repair");
            anim.SetBool("Repair", true);
        }

        //Temporal
        if (Input.GetKeyUp(KeyCode.E) && ground)
        {
            //anim.StopPlayback();
            anim.SetBool("Repair", false);
            StartCoroutine(Wait(0.5f));
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        move = true;
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