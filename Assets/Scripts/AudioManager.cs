using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerPrimary = null;
    public StudioEventEmitter emitterMusicGame = null;
    public VCA vcaMusic, vcaSfx;
    [SerializeField] [Range(0f, 1f)] float volumeMusic = 1f;
    [SerializeField] Slider controlVolume ;
    

    void Start()
    {
        
        audioManagerPrimary = this;
        vcaMusic = RuntimeManager.GetVCA("vca:/MUSIC");
        vcaSfx = RuntimeManager.GetVCA("vca:/SFX");
        AtualizaVolumeMusic(volumeMusic);
    }

    private void Update()
    {
        
        volumeMusic = controlVolume.value;
        AtualizaVolumeMusic(volumeMusic);
    }
    public void AtualizaVolumeMusic(float volume)
    {
        vcaMusic.setVolume(volume);
        vcaSfx.setVolume(volume);
        //Debug.Log(vcaMusic + " v ");
    }

    /*public void TocaMusicaGameplay()
    {
        audio.Stop();
        audio.PlayOneShot(musicGameplay,volumeMusic);
    }

    public void TocaMusicaMainMenu()
    {
        audio.Stop();
        audio.PlayOneShot(musicMainMenu,volumeMusic);
    } */

   

}
