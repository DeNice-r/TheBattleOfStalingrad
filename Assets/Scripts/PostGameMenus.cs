using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostGameMenus : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameWonMenu;
    public GameObject highScoreMenu;
    public Text AScore;
    public Text BScore;
    public Text[] highScores;

    GameObject currentMenu;

    public bool isBaseDead = false;

    private void Update()
    {
        if (isBaseDead)
        {
            GameOver();
            isBaseDead = false;
        }
    }

    public void GameOver()
    {
        setScore();
        currentMenu = gameOverMenu;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameWon()
    {
        setScore();
        currentMenu = gameWonMenu;
        gameWonMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        gameOverMenu.SetActive(false);
        gameWonMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene("Game");
    }

    public void ToMainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void ToHighScores()
    {
        for (int x = 0; x < ScoreMgr.highScores.Length; x++)
            highScores[x].text = ScoreMgr.highScores[x].ToString();
        currentMenu.SetActive(false);
        highScoreMenu.SetActive(true);
    }

    public void goBack()
    {
        highScoreMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    void setScore()
    {
        AScore.text = ScoreMgr.Ascore.ToString();
        BScore.text = ScoreMgr.Bscore.ToString();
        ScoreMgr.newScore();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
