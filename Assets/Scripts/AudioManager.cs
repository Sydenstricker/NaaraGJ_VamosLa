using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip music;
    [SerializeField] [Range(0f, 1f)] float volumeMusic = 0.5f;
    public AudioClip soundFX;
    [SerializeField] [Range(0, 1)] float volumeSFX = 0.75f;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<AudioManager>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        TocaMusic();
        TocaSFX();
    }
    void Update()
    {
        AtualizaVolumeSFX(volumeSFX);
        AtualizaVolumeMusic(volumeMusic);
    }
    private void TocaMusic()
    {
        audio.PlayOneShot(music, volumeMusic);
    }
    private void TocaSFX()
    {
        audio.PlayOneShot(soundFX, volumeSFX);
    }
    public void AtualizaVolumeMusic(float volume)
    {
        audio.GetComponent<AudioSource>().volume = volumeMusic;
        volumeMusic = volume;
    }
    public void AtualizaVolumeSFX(float volume2)
    {
        audio.GetComponent <AudioSource>().volume = volumeSFX;
        volumeSFX = volume2;
    }
}