using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource[] musics;
    [SerializeField] private AudioSource[] sfx;

    public bool isMusicPlaying = false;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    /// <summary>
    /// 0 = menu_music, 1 = park_loop, 2 = Teo_dialogue_underfscore_loop, 4 = Teo_saxophone_loop
    /// </summary>
    public void PlayMusic(int musicToPlay)
    {
        if (musics.Length > 0)
        {
            StopMusics();
            if (musicToPlay < musics.Length)
            {
                musics[musicToPlay].Play();
                isMusicPlaying = true;
            }
        }
    }

    public void StopMusics()
    {
        for (int i = 0; i < musics.Length; i++)
        {
            musics[i].Stop();
        }
        isMusicPlaying = false;
    }

    /// <summary>
    /// 0 = Femme sigh, 1 = Phone buzzing, 2 = Noise of frustration, 3 = something hit miyako, 4 = Heavy steps, 5 = Bump into someone, 6 = footstep(1), 7 = UI buttons
    /// </summary>
    public void PlaySfx(int sfxToPlay)
    {
        if (sfx.Length > 0 && sfxToPlay < sfx.Length)
        {
            sfx[sfxToPlay].Play();
        }
    }
   
}
