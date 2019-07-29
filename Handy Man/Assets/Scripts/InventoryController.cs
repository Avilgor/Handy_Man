using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    Slot []slots = new Slot[3];
    [SerializeField]
    Sprite []tools;
    /*
     * 0 = llaveinglesa
     * 1 = martillo
     * 2 = destornillador
     */


    void Start()
    {
        tools = Resources.LoadAll<Sprite>("tool");
    }

    public void AddInv(string tool)
    {
        GameObject newTool = new GameObject();
        newTool.AddComponent<SpriteRenderer>();
        switch (tool)
        {
            case "Wrench":
                newTool.GetComponent<SpriteRenderer>().sprite = tools[0];
                break;
            case "Hammer":
                newTool.GetComponent<SpriteRenderer>().sprite = tools[1];
                break;
            case "Screwdriver":
                newTool.GetComponent<SpriteRenderer>().sprite = tools[2];
                break;
        }

        int i = 0;
        do
        {
            if (slots[i] != null)
            {
                //newTool.transform.position = slots[i].transform.position;
                i = 3;
            }
            else
            {
                i++;
            }
        } while (i<3);
    }
}
