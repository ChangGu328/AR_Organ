using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio_control : MonoBehaviour
{
    //单列模式 Singleton mode
    public static Audio_control instance;

    [Header("音源 audio source")]
    public AudioSource audio_source;

    [Header("game_start")]
    public AudioClip audio_clip_game_start;

    [Header("game_over")]
    public AudioClip audio_clip_game_over;

    [Header("cut")]
    public AudioClip audio_clip_cut;

    [Header("score")]
    public AudioClip audio_clip_score;

    [Header("show")]
    public AudioClip audio_clip_show;

    [Header("button")]
    public AudioClip audio_clip_btn;

    [Header("ad_success")]
    public AudioClip audio_clip_ad_success;

    [Header("dinosaur_show")]
    public AudioClip audio_clip_dinosaur_show;

    void Awake()
    {
        //跨多场景的单例模式
        #region 
        if (Config.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Audio_control.instance = this;

            //切换场景时不销毁
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }

    public void play_sound_game_start()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_game_start);
        }
    }

    public void play_sound_game_over()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_game_over);
        }
    }

    public void play_sound_cut()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_cut);
        }
    }

    public void play_sound_score()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_score);
        }
    }

    public void play_show_sound()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_score);
        }
    }

    public void play_btn_sound()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_btn);
        }
    }

    public void play_btn_sound_half()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_btn, 0.25f);
        }
    }

    public void play_ad_success_sound()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_ad_success);
        }
    }

    public void play_dinosaur_show_sound()
    {
        if (this.audio_source != null)
        {
            this.audio_source.PlayOneShot(this.audio_clip_dinosaur_show);
        }
    }
}

