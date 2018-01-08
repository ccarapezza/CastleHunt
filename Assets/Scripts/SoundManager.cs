using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioSource[] channels;

    public static SoundManager instance;


    void Awake()
    {
        instance = this;

        channels = new AudioSource[sounds.Length];

        for (int i = 0; i < channels.Length; i++)
        {
            channels[i] = gameObject.AddComponent<AudioSource>();
            channels[i].clip = sounds[i];
        }

    }

    public void Play(SoundID SoundID, bool loop = false, float volumen = 1, int position = 0)
    {
        if (channels[(int)SoundID].isPlaying) return;
        channels[(int)SoundID].loop = loop;
        channels[(int)SoundID].volume = volumen;
        channels[(int)SoundID].time = position;
        channels[(int)SoundID].Play();
    }

    public void Stop(SoundID SoundID)
    {
        if (!channels[(int)SoundID].isPlaying) return;
        channels[(int)SoundID].Stop();
    }

    public void Pause(SoundID SoundID)
    {
        if (!channels[(int)SoundID].isPlaying) return;
        channels[(int)SoundID].Pause();
    }


    public void Resume(SoundID SoundID)
    {
        channels[(int)SoundID].UnPause();
    }

    public void Mute(SoundID SoundID)
    {
        channels[(int)SoundID].mute = !channels[(int)SoundID].mute;
    }
}

public enum SoundID
{
    PUNCH,
    MENU,
    JUMP_1,
    MAGE,
    BOSS,
    GAME,
    JUMP_2,
    ESQUELETIN,
    JEWEL,
    AIRPUNCH,
    LEVER,
    GUNSHOT,
    WIN,
    GAMEOVER,
    BOSS_MUSIC,
    DRAGON_FIREBALL,
    GAMEOVER2,
    POSITIVE_SOUND,
    BOSS_SOUND_B
}
