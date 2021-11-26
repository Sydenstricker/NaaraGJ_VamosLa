using UnityEngine;
using FMODUnity;

public class roudana : MonoBehaviour
{
    private StudioEventEmitter emitterSound;
    public movePlatform objAplicationPosi, objAplicationNegative;
    private bool atived = false;

    // Start is called before the first frame update
    void Start()
    {
        emitterSound = GetComponent<StudioEventEmitter>();
    }

    private void Update()
    {
        if (atived && (!objAplicationNegative || objAplicationNegative.IsInFinalLocal()) && (!objAplicationPosi || objAplicationPosi.IsInFinalLocal()))
        {
            emitterSound.Stop();
            playerControll.player.AtivedRoudana(false);
            atived = false;
        }
    }

    public void Atived()
    {
        atived = true;
        emitterSound.Play();
        if (objAplicationNegative)
        {
            objAplicationNegative.MovePlatform(-1);
        }
        if (objAplicationPosi)
        {
            objAplicationPosi.MovePlatform(1);
        }
    }
}
