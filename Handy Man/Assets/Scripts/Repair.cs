using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    [SerializeField]
    public Slider repairBar;
    public bool repairFinish;
    public bool load;
    public float progress;
    
    void Start()
    {
        //repairBar.gameObject.SetActive(false);
        repairBar.value = 0;
        repairFinish = false;
        load = false;
        progress = 0;
    }

    void Update()
    {
        if (load == true)
        {
            progress += 0.001f;
            repairBar.value = progress;
        }

        if (repairBar.value >= 1)
        {
            repairFinish = true;
            load = false;
        }
    }

    /*public void increaseBar(float num)
    {
        if (repairBar.value >= 1)
        {
            repairFinish = true;   
        }
        else
        {
            repairBar.value += num;
        }
    }*/
}
