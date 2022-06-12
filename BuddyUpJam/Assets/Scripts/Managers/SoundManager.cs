using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource[] musics;
    [Tooltip("0 = Miyako stomach growl, 1 = Miyako frustrated sigh, 2 = Miyako sad sigh, 3 = Miyako text alert, 4 = crane hits miyako, 5 = Miyako angry growl, 6 = Miyako huff puff, 7 = Teo laugh 1, 8 = Teo footsteps, 9 = Bump into Teo, 10 = Miyako footsteps, 11 = teo laugh 2, 12 = UI Button 1, 13 = UI Button 2")]
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
    /// 0 = Miyako stomach growl, 1 = Miyako frustrated sigh, 2 = Miyako sad sigh, 3 = Miyako text alert, 4 = crane hits miyako, 5 = Miyako angry growl, 6 = Miyako huff puff, 7 = Teo laugh 1, 8 = Teo footsteps, 9 = Bump into Teo, 10 = Miyako footsteps, 11 = teo laugh 2, 12 = UI Button 1, 13 = UI Button 2
    /// </summary>
    public void PlaySfx(int sfxToPlay)
    {
        if (sfx.Length > 0 && sfxToPlay < sfx.Length)
        {
            sfx[sfxToPlay].Play();
        }
    }
   
}
