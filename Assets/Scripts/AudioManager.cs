using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{  
    private AudioSource audio;
    public AudioClip music;
    public AudioClip musicGameplay;
    [SerializeField] [Range(0f, 1f)] float volumeMusic = 0.5f;
    public AudioClip soundFX;
    [SerializeField] [Range(0, 1)] float volumeSFX = 0.75f;
    public AudioClip hpNave;
    [SerializeField] [Range(0, 1)] float volumehpNave = 0.75f;
    [SerializeField] bool isMainMenu = false;
    [SerializeField] bool isGameplay = false;

    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(isMainMenu)
        {
            TocaMusic();
        }
        if(isGameplay)
        {
            TocaMusicaGameplay();
        }
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
    public void TocaMusicaGameplay()
    {
        audio.Stop();
        audio.PlayOneShot(musicGameplay,volumeMusic);
    }
    public void TocaMusicaMainMenu()
    {
        audio.Stop();
        audio.PlayOneShot(music,volumeMusic);
    } 
    public void HPNave()
    {
        audio.PlayOneShot(hpNave, volumehpNave);
    }

}
