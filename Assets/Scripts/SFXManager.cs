using UnityEngine;
using FMODUnity;

public class SFXManager : MonoBehaviour
{
    public StudioEventEmitter soundTest;
    [SerializeField]
    private bool trigger = false;

    public void AtualizaVolumeSFX(float volume2)
    {
        trigger = true;
        AudioManager.audioManagerPrimary.vcaSfx.setVolume(volume2);

        if (!soundTest.IsPlaying())
        {
            soundTest.Play();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(123);

        if (!trigger && soundTest.IsPlaying())
        {
            soundTest.Stop();
        }
    }

    private void LateUpdate()
    {
        trigger = false;
    }
}

