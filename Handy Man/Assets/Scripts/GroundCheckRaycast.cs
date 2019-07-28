using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckRaycast : MonoBehaviour
{
    public LayerMask groundLayer;
    Vector2 direction = Vector2.down;
    public float distance = 1.0f;

    void Start()
    {
        
    }


    void Update()
    {
        Debug.DrawRay(transform.position, direction * distance, Color.red, 0.5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, groundLayer);

        if (hit.collider != null)
            GetComponent<MovementController>().ground = true;
        
        else
            GetComponent<MovementController>().ground = false;

    }
}