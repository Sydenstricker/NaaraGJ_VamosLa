using UnityEngine;
using FMODUnity;

public class chkPoint : MonoBehaviour
{
    public StudioEventEmitter eventEmitter;
    private Transform playerNear = null;
    private bool triggerAtived = false;
    private float countTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (triggerAtived)
        {
            countTime += Time.deltaTime / 3f;
            if (countTime > 1f)
            {
                gameObject.SetActive(false);
            }
            else
            {

                AudioManager.audioManagerPrimary.emitterMusicGame.SetParameter("checkpoint distance", (1f - countTime) * 20f);
            }
        }
        else if (playerNear)
        {
            float distTarget = Vector2.Distance(transform.position, playerNear.transform.position);
            float volume = (5f - distTarget) / 5f;
            if (volume > 1f)
            {
                volume = 1f;
            }
            else if (volume < 0f)
            {
                volume = 0f;
            }

            
            AudioManager.audioManagerPrimary.emitterMusicGame.SetParameter("checkpoint distance", 20f * volume);

            if (distTarget <= 1f)
            {
                triggerAtived = true;
                eventEmitter.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggerAtived)
        {
            playerNear = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(playerNear == collision.transform && !triggerAtived)
        {
            playerNear = null;
        }
    }
}
