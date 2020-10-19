using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour
{

    public Text AScore;
    public Text BScore;


    public static int Ascore = 0;
    public static int Bscore = 0;

    private void Update()
    {
        AScore.text = Ascore.ToString();
        BScore.text = Bscore.ToString();
    }

    public static void AddScore(string info, int pts)
    {
        if (info.Contains("Tank A"))
            Ascore += pts;
        else if (info.Contains("Tank B"))
            Bscore += pts;
    }
}
