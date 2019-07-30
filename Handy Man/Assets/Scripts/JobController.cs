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

public class JobController : MonoBehaviour
{
    [SerializeField]
    GameObject JobFolder, JobIcon;
    public ScrollRect scrollView;
    public GameObject content;
    public GameObject prefab;
    private System.Random rnd;
    private int currentJobs;
    private float timeLapse;

    void Start()
    {
        rnd = new System.Random();
        generateJob(); generateJob();
        currentJobs = 2;
        timeLapse = 0;
    }

    void Update()
    {
        timeLapse += Time.deltaTime;
        if (timeLapse > 30)
        {
            if (currentJobs < 10)
            {
                generateJob();
                currentJobs++;
                timeLapse = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (JobIcon.activeSelf == false)
            {
                JobIcon.SetActive(true);
            }
            else
            {
                JobIcon.SetActive(false);
            }

            if (JobFolder.activeSelf == false)
            {
                JobFolder.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
                JobFolder.SetActive(false);
            }
        }
    }

    public void generateJob()
    {
        GameObject item = Instantiate(prefab);
        item.transform.SetParent(content.transform, false);

        item.GetComponent<Job>().NewJob(Enum.GetName(typeof(Cars), rnd.Next(1, 17)), rnd.Next(1, 10) / 1000, rnd.Next(15, 30) * 10);
        item.GetComponent<Job>().showValues();
    }
}
