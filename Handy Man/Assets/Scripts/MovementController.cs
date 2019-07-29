using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer renderer;
    float velocity=1f,jumpForce=7f;
    public bool ground,repairZone;
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
        move = true;
        repairZone = false;
    }


    void Update()
    {
        /*if (ground==false)
        {
            rb.velocity -= new Vector2(0f, 0.02f * Time.timeScale);
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



        else if (Input.GetKey(KeyCode.D) && !ground && move && !Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x < 4)
            {
                rb.velocity += new Vector2((velocity/2) * Time.timeScale, 0f);
            }
            renderer.flipX = false;
        }

        else if (Input.GetKey(KeyCode.A) && !ground && move && !Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x > -4)
            {
                rb.velocity -= new Vector2((velocity / 2) * Time.timeScale, 0f);
            }
            renderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.Space) && ground || Input.GetKey(KeyCode.W) && ground)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            rb.AddForce(new Vector2(0f, jumpForce * Time.timeScale), ForceMode2D.Impulse);
            anim.Play("Jump");
            ground = false;
        }


        if (rb.velocity.magnitude == 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && ground)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKey(KeyCode.E) && ground)
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

            if (repairZone == true && GetComponent<Repair>().repairFinish == false)
            {
                GetComponent<Repair>().load = true;
            }

            anim.SetBool("Repair", true);
        }

        if (Input.GetKeyUp(KeyCode.E) && ground)
        {
            anim.SetBool("Repair", false);
            GetComponent<Repair>().load = false;
            if (GetComponent<Repair>().repairFinish == true)
            {
                Debug.Log("Repair finished");
                GetComponent<Repair>().repairBar.value = 0;
                GetComponent<Repair>().progress = 0;
                GetComponent<Repair>().repairFinish = false;
            }
            else
            {
                Debug.Log("Repair unfinished");
                GetComponent<Repair>().repairBar.value = 0;
                GetComponent<Repair>().progress = 0;
                GetComponent<Repair>().repairFinish = false;
            }
            StartCoroutine(Wait(0.5f));
        }

        /*if (rb.velocity.y < 0 && !ground)
        {
            rb.gravityScale = 2.7f;
        }
        else if (rb.velocity.y >= 0 && !ground)
        {
            rb.gravityScale = 1f;
        }*/
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        move = true;
    }
}