using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

enum Cars
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
    Cars carList;

    void Start()
    {
        rnd = new System.Random();
        scrollView.verticalNormalizedPosition = 1;
    }

    public void generateJob()
    {
        GameObject item = Instantiate(prefab);
        item.transform.SetParent(content.transform,false);

        float time = rnd.Next(1, 10) / 1000;
        int reward = 10 - ((int)time * 1000);
        reward = (reward * 75);

        item.GetComponent<Job>().NewJob(Enum.GetName(typeof(Cars), rnd.Next(1, 17)), time,reward);
        item.GetComponent<Job>().showValues();
    }
}
