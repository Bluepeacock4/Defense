using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider seSlider;

    public TextMeshProUGUI masterVolume;
    public TextMeshProUGUI bgmVolume;
    public TextMeshProUGUI seVolume;

    public AudioSource bgmSound;
    public AudioSource seSound;
    public AudioClip[] bgmClip;
    public AudioClip[] seClip;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static AudioManager Instance => _instance == null ? null : _instance;

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);
        float _masterVolume = Mathf.Floor(masterSlider.value * 100);
        masterVolume.text = _masterVolume.ToString();
    }

    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
        float _bgmVolume = Mathf.Floor(bgmSlider.value * 100);
        bgmVolume.text = _bgmVolume.ToString();
    }

    public void SetSeVolume()
    {
        audioMixer.SetFloat("SE", Mathf.Log10(seSlider.value) * 20);
        float _seVolume = Mathf.Floor(seSlider.value * 100);
        seVolume.text = _seVolume.ToString();
        seSound.clip = seClip[0];

        if (!seSound.isPlaying)
        {
            seSound.Play();
        }

    }

    #region AudioClip

    public void Title()
    {
        bgmSound.clip = bgmClip[0];
        bgmSound.Play();
    }

    public void Game()
    {
        bgmSound.clip = bgmClip[1];
        bgmSound.Play();
    }

    public void Click()
    {
        seSound.clip = seClip[0];
        seSound.Play();
    }
    public void Hit()
    {
        seSound.clip = seClip[1];
        seSound.Play();
    }

    #endregion AudioClip
}
