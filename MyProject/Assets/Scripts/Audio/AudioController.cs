using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource BgmAudio;
    [SerializeField] AudioSource SfxAudio;

    [Header("BGM")]
    public AudioClip bgm;
    [Header("Gun")]
    public AudioClip machienGun;
    public AudioClip sniperGun;
    public AudioClip bombGun;
    public AudioClip bombBullet;
    [Header("Skill")]
    public AudioClip bomb;

    public void Start()
    {
        BgmAudio.clip = bgm;
        BgmAudio.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxAudio.PlayOneShot(clip);
    }
}
