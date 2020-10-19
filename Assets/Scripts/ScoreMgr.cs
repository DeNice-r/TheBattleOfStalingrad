using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour
{

    public Text AScore;
    public Text BScore;

    public static bool twoPlayers;
    public GameObject secondPlayer;

    public static int Ascore = 0;
    public static int Bscore = 0;

    public static int[] highScores = new int[] { 0, 0, 0, 0, 0 };

    private void Start()
    {
        Ascore = 0;
        Bscore = 0;
        load();
        secondPlayer.SetActive(twoPlayers);
    }

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

    public static void newScore()
    {
        int sum = scoreSum();
        if (highScores[4] < sum)
        {
            highScores[4] = sum;
            sort();
        }
        save();
    }

    public static int scoreSum()
    {
        return Ascore + Bscore;
    }

    static void sort()
    {
        Array.Sort(highScores);
        Array.Reverse(highScores);
    }

    private void OnApplicationQuit()
    {
        save();
    }

    public static void load()
    {
        string info = PlayerPrefs.GetString("HighScores");
        var scores = info.Split('|');
        for (var n = 0; n < scores.Length; n++)
        {
            highScores[n] = Convert.ToInt32(scores[n]);
        }
        sort();
    }

    public static void save()
    {
        string info = "";
        sort();
        foreach (var h in highScores)
            info += h.ToString() + "|";
        PlayerPrefs.SetString("HighScores", info.Substring(0, info.Length - 1));
    }
}
