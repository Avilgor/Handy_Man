using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

enum Cars2
{
    Micro = 1,
    Sedan,
    Cuv,
    Sub,
    Hatchback,
    Roadster,
    Pickup,
    Van,
    Coupe,
    Supercar,
    Campervan,
    MiniTruck,
    Cabriolet,
    Minivan,
    Truck,
    BigTruck
};

public class ScrollList : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject content;
    public GameObject prefab;
    private System.Random rnd;
    

    void Start()
    {
        rnd = new System.Random();
        //scrollView.verticalNormalizedPosition = 1;
    }

    public void generateJob()
    {
        GameObject item = Instantiate(prefab);
        item.transform.SetParent(content.transform,false);

        item.GetComponent<Job>().NewJob(Enum.GetName(typeof(Cars2), rnd.Next(1, 17)), rnd.Next(1, 10) / 1000, rnd.Next(15, 30) * 10);
        item.GetComponent<Job>().showValues();
    }
}
