using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<MovementController>().ground = true;
        }

        if (collision.gameObject.tag == "Tool")
        {
            GetComponent<InventoryController>().AddInv(collision.gameObject.name);
            collision.gameObject.SetActive(false);
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Repair")
        {
            GetComponent<MovementController>().repairZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<MovementController>().ground = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Repair")
        {
            GetComponent<MovementController>().repairZone = false;
            GetComponent<MovementController>().ground = true;
        }
    }
}
