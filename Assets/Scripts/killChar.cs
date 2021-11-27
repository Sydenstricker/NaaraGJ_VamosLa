using UnityEngine;

public class killChar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.Morrer();
        }
    }
}
