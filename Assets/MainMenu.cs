using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScoreMenu;

    public Text[] scores;

    // Start is called before the first frame update
    void Start()
    {
        ScoreMgr.load();
    }

    public void Start1P()
    {
        ScoreMgr.twoPlayers = false;
        SceneManager.LoadScene(1);
    }

    public void Start2P()
    {
        ScoreMgr.twoPlayers = true;
        SceneManager.LoadScene(1);
    }

    public void toHighScores()
    {
        for(int n = 0; n < 5; n++)
        {
            scores[n].text = ScoreMgr.highScores[n].ToString();
        }
        mainMenu.SetActive(false);
        highScoreMenu.SetActive(true);
    }

    public void goBack()
    {
        mainMenu.SetActive(true);
        highScoreMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
