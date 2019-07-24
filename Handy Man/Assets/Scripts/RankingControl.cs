using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public static class RankingControl
{
    static string path = Application.dataPath + "/StreamingAssets/Ranking.txt";

    public static List<Ranking> doList()
    {
        StreamReader reader = new StreamReader(path);
        //String readIn = "";

        List<Ranking> list = new List<Ranking>();
        List<Ranking> sorted = new List<Ranking>();

        String[] results = new string[3];

        for (int i = 0; i < 5; i++)
        {
            results = reader.ReadLine().Split('/');
            if (results == null)
            {
                Debug.Log("Null returned on reading file -Ranking-");
            }
            else
            {
                Ranking a = new Ranking(results[1], Int32.Parse(results[2]));
                list.Add(a);
            }          
        }
        reader.Close();
        sorted = list.OrderByDescending(o => o.score).ToList();

        return sorted;
    }

    /*static String ReadLine(string path,bool close=false)
    {
        StreamReader reader = new StreamReader(path);
        String readIn = "";
   
        readIn = reader.ReadLine();
        if (close)
        {
            reader.Close();
        }

        if (readIn == null)
        {
            Debug.Log("Line read is NULL");
            reader.Close();
            return "";
        }
        else
        {
            return readIn;
        }        
    }*/
}