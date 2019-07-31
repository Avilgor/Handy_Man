using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Job : MonoBehaviour
{
    [SerializeField]
    Text carTxt,rewardTxt;
 
    GameObject player;

    private string Car;
    private float time;
    private int reward;


    public void NewJob(string name,float duration, int points)
    {
        Car = name;
        time = duration;
        reward = points;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void showValues()
    {
        carTxt.text = "Car type: " + Car;
        rewardTxt.text = "Reward: " + reward.ToString() + " points.";
    }

    public void acceptJob()
    {
        if (player.GetComponent<JobController>().inJob == false)
        {                   
            player.GetComponent<JobController>().currentReward = reward;
            player.GetComponent<JobController>().currentTime = time;
            player.GetComponent<JobController>().inJob = true;
            gameObject.GetComponent<Animation>().Play("Paper");
        }      
    }

    public void deleteJob()
    {
        Destroy(gameObject);
    }

    public string getCar() { return Car; }
    public float getTime() { return time; }
    public int getReward() { return reward; }
}