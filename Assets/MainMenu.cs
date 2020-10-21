using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScoreMenu;
    public AudioMgr audioMgr;
    public Slider loudslider;
    public GameObject unmute;
    public GameObject mute;

    [Range(0f, 1f)]
    public static float lastLoudness;

    public Text[] scores;

    void Start()
    {
        ScoreMgr.load();
        loudslider.value = PlayerPrefs.GetFloat("volume");
        audioMgr.UpdVolume();
        UpdMuter();
    }

    public void Start1P()
    {
        PlayerPrefs.SetInt("two players", 0);
        SceneManager.LoadScene(1);
    }

    public void Start2P()
    {
        PlayerPrefs.SetInt("two players", 1);
        SceneManager.LoadScene(1);
    }

    public void toHighScores()
    {
        for (int n = 0; n < 5; n++)
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

    public void Muter()
    {
        var m = PlayerPrefs.GetInt("mute");
        if (m == 1)
            PlayerPrefs.SetInt("mute", 0);
        else
            PlayerPrefs.SetInt("mute", 1);
        UpdMuter();
        audioMgr.UpdVolume();
    }

    public void UpdMuter()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            unmute.SetActive(false);
            mute.SetActive(true);
        }
        else
        {
            unmute.SetActive(true);
            mute.SetActive(false);
        }
    }

    public void VolChanged()
    {
        audioMgr.SetVolume(loudslider.value);
    }
}
