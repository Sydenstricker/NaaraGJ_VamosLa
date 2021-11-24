using UnityEngine;

public class thingPush : MonoBehaviour
{
    private bool isPusnhing;
    public Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isPusnhing = false;
    }

    public void PushObj(Transform objPush)
    {
        transform.SetParent(objPush);
    }
}
