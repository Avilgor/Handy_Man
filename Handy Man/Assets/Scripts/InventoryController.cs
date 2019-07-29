using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    Image []slots;
    [SerializeField]
    Sprite []tools;
    /*
     * 0 = llaveinglesa
     * 1 = martillo
     * 2 = destornillador
     */

    private bool[]slotsUsed;

    void Start()
    {
        slotsUsed = new bool[slots.Length];
        for (int a = 0; a < slotsUsed.Length; ++a)
        {
            slotsUsed[a] = false;
        }
    }

    public void AddInv(string tool)
    {
        int i = 0;

        switch (tool)
        {
            case "Wrench":
                do
                {
                    if (slotsUsed[i] == false)
                    {
                        slots[i].sprite = tools[0];
                        slotsUsed[i] = true;
                        i = 3;
                    }
                    else
                    {
                        i++;
                    }
                } while (i < slotsUsed.Length);
                
                break;
            case "Hammer":
                do
                {
                    if (slotsUsed[i] == false)
                    {
                        slots[i].sprite = tools[1];
                        slotsUsed[i] = true;
                        i = 3;
                    }
                    else
                    {
                        i++;
                    }
                } while (i < slotsUsed.Length);
                break;
            case "Screwdriver":
                do
                {
                    if (slotsUsed[i] == false)
                    {
                        slots[i].sprite = tools[2];
                        slotsUsed[i] = true;
                        i = 3;
                    }
                    else
                    {
                        i++;
                    }
                } while (i < slotsUsed.Length);              
                break;
        }

        
    }
}
