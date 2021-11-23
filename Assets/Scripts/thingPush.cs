using UnityEngine;

public class thingPush : MonoBehaviour
{
    private bool isPusnhing;

    private void FixedUpdate()
    {
        isPusnhing = false;
    }

    public void PushObj(Transform objPush)
    {
        transform.SetParent(objPush);
    }
}
