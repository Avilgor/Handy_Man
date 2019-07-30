using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Job : MonoBehaviour
{
    [SerializeField]
    Text carTxt,rewardTxt;

    private string Car;
    private float time;
    private int reward;


    public void NewJob(string name,float duration, int points)
    {
        Car = name;
        time = duration;
        reward = points;
    }

    public void showValues()
    {
        carTxt.text = "Car type: " + Car;
        rewardTxt.text = "Reward: " + reward.ToString() + "points.";
    }

    public string getCar() { return Car; }
    public float getTime() { return time; }
    public int getReward() { return reward; }
}