using UnityEngine;
using FMODUnity;

public class playerControll : MonoBehaviour
{
    private movement2D movement;
    [SerializeField]
    private Vector2 sizeDown = Vector2.one;
    private Vector2 sizeOrg;
    [SerializeField]
    private StudioEventEmitter emitterPush = null;
    private thingPush thingPushHere = null;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<movement2D>();
        sizeOrg = GetComponent<CapsuleCollider2D>().size;
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animatorControll2D animatorControll = movement.GetAnimaControll();

        if (move.y < 0f && !thingPushHere)
        {
            if(animatorControll.GetIdAnimaNow() != "Down")
            {
                animatorControll.SetActionAnimation("Down", true, false);
                CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
                capsule.size = sizeDown;
                Vector2 offset = capsule.offset;
                offset.y = sizeDown.y / 2f;
                capsule.offset = offset;
            }
        }
        else if (movement.DistancieGround() == 0f && Input.GetButton("Fire2"))
        {
            if (!thingPushHere)
            {
                //Debug.Log(1);
                Vector2 posCenter = movement.GetCollider().bounds.center;
                Vector2 sizPush = movement.GetCollider().bounds.size / 2f;
                float dist = movement.GetCollider().bounds.size.x;

                Vector2 dire = Vector2.right;

                if (transform.eulerAngles.y == 180f)
                {
                    dire *= -1f;
                }

                RaycastHit2D raycastHit = Physics2D.BoxCast(posCenter, sizPush, movement.AngGround(), dire, dist, repository.repositoryX.GetLayerMaskGround());
                if (raycastHit.collider)
                {
                    //Debug.Log(2);

                    thingPush thingP = raycastHit.collider.GetComponent<thingPush>();
                    if (thingP)
                    {
                        thingP.PushObj(transform);
                        thingPushHere = thingP;
                    }
                }
            }
        }
        else if(thingPushHere)
        {
            thingPushHere.PushObj(null);
            thingPushHere = null;
        }

        if(animatorControll.GetIdAnimaNow() == "Down" && move.y >= 0f)
        {
            animatorControll.SetNormalState();
            CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
            capsule.size = sizeOrg;
            Vector2 offset = capsule.offset;
            offset.y = sizeOrg.y / 2f;
            capsule.offset = offset;
        }

        if (!thingPushHere)
        {
            if(animatorControll.GetIdAnimaNow() == "Push")
            {
                animatorControll.SetNormalState();
            }

            if (!movement.enabled)
            {
                movement.enabled = true;
            }
            movement.MakeMove(move);
        }
        else if(animatorControll.GetIdAnimaNow() != "Push")
        {
            animatorControll.SetActionAnimation("Push", true, false);
        }

        if (Input.GetButtonDown("Jump") && !thingPushHere)
        {
            movement.MakeJump();
        }

        if (thingPushHere)
        {
            movement.enabled = false;
            Rigidbody2D body = movement.GetRigidbody2D();
            if(body.constraints != RigidbodyConstraints2D.FreezeRotation)
            {
                body.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            Vector2 speed = move;
            speed.y = 0f;
            speed = Quaternion.Euler(Vector3.forward * movement.AngGround()) * speed.normalized;
            body.velocity = speed;
        }
    }
}
