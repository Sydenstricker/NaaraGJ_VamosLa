using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{  
    private AudioSource audio;
    public AudioClip musicMainMenu;
    public AudioClip musicGameplay;
    [SerializeField] [Range(0f, 1f)] float volumeMusic = 0.5f;    
    
    [SerializeField] bool isMainMenu = false;
    [SerializeField] bool isGameplay = false;

    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(isMainMenu)
        {
            TocaMusicMainMenu();
        }
        if(isGameplay)
        {
            TocaMusicaGameplay();
        }        
    }
    void Update()
    {
        AtualizaVolumeMusic(volumeMusic);
    }
    private void TocaMusicMainMenu()
    {
        audio.PlayOneShot(musicMainMenu, volumeMusic);
    }
    
    public void AtualizaVolumeMusic(float volume)
    {
        audio.GetComponent<AudioSource>().volume = volumeMusic;
        volumeMusic = volume;
    }
    
    public void TocaMusicaGameplay()
    {
        audio.Stop();
        audio.PlayOneShot(musicGameplay,volumeMusic);
    }
    public void TocaMusicaMainMenu()
    {
        audio.Stop();
        audio.PlayOneShot(musicMainMenu,volumeMusic);
    } 

}
