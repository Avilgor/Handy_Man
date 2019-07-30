using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Job 
{
    private string Car;
    private float time;
    private int reward;
    private System.Random rnd;

    public Job(string name)
    {
        rnd = new System.Random();
        Car = name;
        time = rnd.Next(1,10) / 1000;
        reward = 10 - ((int)time * 1000);
        reward = (reward * 75);
    }

    public string getCar() { return Car; }
    public float getTime() { return time; }
    public int getReward() { return reward; }
}