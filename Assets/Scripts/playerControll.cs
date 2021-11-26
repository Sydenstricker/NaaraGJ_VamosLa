using UnityEngine;
using FMODUnity;

public class playerControll : MonoBehaviour
{
    public static playerControll player;
    private movement2D movement;
    [SerializeField]
    private Vector2 sizeDown = Vector2.one;
    private Vector2 sizeOrg;
    [SerializeField]
    private StudioEventEmitter emitterPush = null;
    private thingPush thingPushHere = null;
    private bool triggerGoingUp = false, interactTrigger = false;

    // Start is called before the first frame update
    void Awake()
    {
        player = this;
        movement = GetComponent<movement2D>();
        sizeOrg = GetComponent<CapsuleCollider2D>().size;
    }

    private void Update()
    {
        if (!interactTrigger)
        {
            Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            animatorControll2D animatorControll = movement.GetAnimaControll();

            if (move.y < 0f && movement.DistancieGround() == 0f && !thingPushHere)
            {
                if (animatorControll.GetIdAnimaNow() != "Down")
                {
                    movement.SetMultSpeed(0f);
                    animatorControll.SetActionAnimation("Down", true, false);
                    CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
                    capsule.size = sizeDown;
                    Vector2 offset = capsule.offset;
                    offset.y = sizeDown.y / 2f;
                    capsule.offset = offset;
                }
            }
            else if (movement.DistancieGround() == 0f && (Input.GetButton("Fire2") || Input.GetButton("Fire1")))
            {
                Vector2 posCenter = movement.GetCollider().bounds.center;
                Collider2D coll = Physics2D.OverlapCircle(posCenter, 1f, repository.repositoryX.GetLayerMaskInteract());

                roudana roudanaX = null;

                if (coll)
                {
                    roudanaX = coll.GetComponent<roudana>();
                }

                if (roudanaX)
                {
                    roudanaX.Atived();
                    AtivedRoudana(true);
                }
                else if (!thingPushHere)
                {
                    //Debug.Log(1);
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
            else if (thingPushHere)
            {
                thingPushHere.PushObj(null);
                thingPushHere = null;
            }

            if (animatorControll.GetIdAnimaNow() == "Down" && move.y >= 0f && !triggerGoingUp)
            {
                triggerGoingUp = true;
                animatorControll.AtivedTriggerAnima();
            }

            if (!thingPushHere)
            {
                if (animatorControll.GetIdAnimaNow() == "Push")
                {
                    animatorControll.SetNormalState();
                }

                if (!movement.enabled)
                {
                    movement.enabled = true;
                }
                movement.MakeMove(move);
            }
            else if (animatorControll.GetIdAnimaNow() != "Push")
            {
                animatorControll.SetActionAnimation("Push", true, false);
            }

            if (Input.GetButtonDown("Jump") && !thingPushHere)
            {
                movement.MakeJump();
            }

            bool pushing = false;
            if (thingPushHere)
            {
                movement.enabled = false;
                Rigidbody2D body = movement.GetRigidbody2D();
                if (body.constraints != RigidbodyConstraints2D.FreezeRotation)
                {
                    body.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                Vector2 speed = move;
                speed.y = 0f;
                speed = Quaternion.Euler(Vector3.forward * movement.AngGround()) * speed.normalized;
                body.velocity = speed;
                thingPushHere.body.velocity = speed;
                if (speed.sqrMagnitude != 0f)
                {
                    if (!emitterPush.IsPlaying())
                    {
                        emitterPush.Play();
                    }

                    pushing = true;
                }
            }

            if (emitterPush.IsPlaying() && !pushing)
            {
                emitterPush.Stop();
            }
        }
    }

    public void GoingUp()
    {
        triggerGoingUp = false;
        movement.GetAnimaControll().SetNormalState();
        CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
        capsule.size = sizeOrg;
        Vector2 offset = capsule.offset;
        offset.y = sizeOrg.y / 2f;
        capsule.offset = offset;
        movement.SetMultSpeed(1f);
    }

    public void AtivedRoudana(bool atv)
    {
        interactTrigger = atv && !thingPushHere;

        if (interactTrigger)
        {
            movement.SetCanMove(false);
            movement.GetAnimaControll().SetActionAnimation("Push", false, false);
        }
        else
        {
            movement.SetCanMove(true);
            movement.GetAnimaControll().SetNormalState();
        }
    }
}
