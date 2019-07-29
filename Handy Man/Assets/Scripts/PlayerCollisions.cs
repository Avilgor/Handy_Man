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
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<MovementController>().ground = false;
        }
    }
}
