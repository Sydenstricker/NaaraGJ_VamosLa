using UnityEngine;

public class colletable : MonoBehaviour
{
    public bool multGold = false;
    public string description;
    //public AudioClip clipPlayGetted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inventory inv = collision.GetComponent<inventory>();

        if (inv)
        {
            if (multGold)
            {
                Pepita.multiplicadorOuro = 2;
            }
            inv.AddItem(this);
            gameObject.SetActive(false);
            itensCollectInf.itensCollectX.CollectImportantItem(GetComponentInChildren<SpriteRenderer>().sprite, description);
        }
    }
}
