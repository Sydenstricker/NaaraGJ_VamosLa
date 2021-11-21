using UnityEngine;

public class thingPush : MonoBehaviour
{
    private Rigidbody2D rigidbodyHere;
    private bool isPusnhing;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyHere = GetComponent<Rigidbody2D>();
        rigidbodyHere.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate()
    {
        isPusnhing = false;
    }

    private void LateUpdate()
    {
        if (!isPusnhing)
        {
            PushObj(Vector2.zero);
        }
    }

    public void PushObj(Vector2 pushMovement)
    {
        rigidbodyHere.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (pushMovement.sqrMagnitude == 0f)
        {
            rigidbodyHere.constraints |= RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            Vector2 pos = rigidbodyHere.position + pushMovement;
            rigidbodyHere.MovePosition(pos);
            isPusnhing = true;
        }
    }
}
