using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class AudioMgr : MonoBehaviour
{
    public bool menu;

    [Range(0f, 1f)]

    public Sound mainMenuMusic;
    public Sound[] music;

    private void Awake()
    {
        mainMenuMusic.Init(gameObject.AddComponent<AudioSource>());
        foreach (Sound s in music)
        {
            s.Init(gameObject.AddComponent<AudioSource>());
        }
    }

    private void Start()
    {
        if (menu)
        {
            StopAll();
            mainMenuMusic.src.Play();
        }
        else
        {
            StopAll();
            StartCoroutine("PlayBGMusic");
        }
    }

    IEnumerator PlayBGMusic()
    {
        while (true)
        {
            int idx = (int)Math.Round(Random.value * (music.Length -1 ));
            music[idx].src.Play();
            yield return new WaitForSeconds(music[idx].clip.length);
        }
        
    }

    public void StopAll()
    {
        StopCoroutine("PlayBGMusic");
        mainMenuMusic.src.Stop();
        foreach (var m in music)
            m.src.Stop();
    }

    public void UpdVolume()
    {
        SetVolume(PlayerPrefs.GetFloat("volume"));
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        var mute = PlayerPrefs.GetInt("mute");
        //StopCoroutine("PlayBGMusic");
        mainMenuMusic.src.volume = (mute == 1) ? 0f : volume;
        foreach (var m in music)
            m.src.volume = (mute == 1) ? 0f : volume;
    }
}
