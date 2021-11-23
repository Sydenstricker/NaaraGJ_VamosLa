using UnityEngine;

public class colletable : MonoBehaviour
{
    public string description;
    public AudioClip clipPlayGetted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inventory inv = collision.GetComponent<inventory>();

        if (inv)
        {
            inv.AddItem(this);
            gameObject.SetActive(false);
        }
    }
}
