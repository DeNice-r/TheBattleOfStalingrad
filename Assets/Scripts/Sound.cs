using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource src;

    public void Init(AudioSource s)
    {
        var vol = PlayerPrefs.GetFloat("volume");
        var mute = PlayerPrefs.GetInt("mute");
        src = s;
        src.clip = clip;
        src.volume = (mute == 1) ? 0f : vol;
        src.pitch = 1f;
        src.loop = loop;
    }
}
