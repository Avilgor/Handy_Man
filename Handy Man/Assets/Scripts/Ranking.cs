using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking
{
    public int score = 0;
    public string name = "";

    public Ranking(string name, int score)
    {
        this.score = score;
        this.name = name;
    }
}