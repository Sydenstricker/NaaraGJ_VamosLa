using UnityEngine;

public class triggerAnimaEvent : MonoBehaviour
{
    private movement2D movement;
    private playerControll playerControll;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponentInParent<movement2D>();
        playerControll = GetComponentInParent<playerControll>();
    }

    
    public void JumpForce()
    {
        //movement.AddForceJump();
    }

    public void ReturnNormalState()
    {
        movement.GetAnimaControll().SetNormalState();
    }

    public void GoingUp()
    {
        playerControll.GoingUp();
    }

    public void BeforeGroundFalling()
    {
        movement.SetMultSpeed(1f);
        movement.GetAnimaControll().SetNormalState();

    }
}
