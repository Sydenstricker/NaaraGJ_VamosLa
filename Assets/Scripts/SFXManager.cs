using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip soundFX;
    [SerializeField] [Range(0f, 1f)] float volumeSFX = 0.5f;
    public AudioClip hpNave;
    [SerializeField] [Range(0, 1)] float volumehpNave = 0.75f;
    public AudioClip puloSFX;
    [SerializeField] [Range(0, 1)] float volumePulo = 0.75f;
    public AudioClip ataqueSFX;
    [SerializeField] [Range(0, 1)] float volumeAtaque = 0.75f;
    public AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float volumeDeath = 0.75f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //TocaSFXIntro();
    }

    // Update is called once per frame
    void Update()
    {
        AtualizaVolumeSFX(volumeSFX);
        if(Input.GetKeyUp(KeyCode.Q)) //testar SFX, na build final apagar
        {
            AtaqueSFX();
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            PuloSFX();
        }
        if(Input.GetKeyUp (KeyCode.A))
        {
            DeathSFX();
        }
        if(Input.GetKeyUp (KeyCode.Space))
        {
            PuloSFX();
        }
    }
    private void TocaSFXIntro()
    {
        audio.PlayOneShot(soundFX, volumeSFX);
    }
    public void AtualizaVolumeSFX(float volume2)
    {
        audio.GetComponent<AudioSource>().volume = volumeSFX;
        volumeSFX = volume2;
    }
    public void HPNave()
    {
        audio.PlayOneShot(hpNave, volumehpNave);
    }
    public void AtaqueSFX()
    {
        audio.PlayOneShot(ataqueSFX, volumeAtaque);
    }
    public void PuloSFX()
    {
        audio.PlayOneShot(puloSFX,volumePulo);
    }
    public void DeathSFX()
    {
        audio.PlayOneShot(deathSFX, volumeDeath);
    }
}
