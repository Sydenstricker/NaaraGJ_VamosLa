using UnityEngine;

public class playerControll : MonoBehaviour
{
    private movement2D movement;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<movement2D>();
    }

    private void Update()
    {
        bool isPushing = false;
        Vector2 move = Input.GetAxisRaw("Horizontal") * Vector2.right;

        if (movement.DistancieGround() == 0f && move.sqrMagnitude != 0f && movement.GetObstacle(move))
        {
            //Debug.Log(1);
            Vector2 posCenter = movement.GetCollider().bounds.center;
            Vector2 sizPush = movement.GetCollider().bounds.size / 2f;
            float dist = movement.GetCollider().bounds.size.x;

            RaycastHit2D raycastHit = Physics2D.BoxCast(posCenter, sizPush, movement.AngGround(), move, dist, repository.repositoryX.GetLayerMaskGround());
            if (raycastHit.collider)
            {
                //Debug.Log(2);

                thingPush thingP = raycastHit.collider.GetComponent<thingPush>();
                if (thingP)
                {
                    //Debug.Log(3);

                    Vector2 push = Quaternion.Euler(Vector3.forward * movement.AngGround()) * move * Time.deltaTime * 12f;
                    thingP.PushObj(push);

                    movement.enabled = false;
                    Rigidbody2D bodyHere = movement.GetRigidbody2D();
                    bodyHere.constraints = RigidbodyConstraints2D.FreezeRotation;
                    Vector2 posGo = bodyHere.position + push;
                    bodyHere.MovePosition(posGo);

                    isPushing = true;
                }
            }
        }

        if (!isPushing)
        {
            if (!movement.enabled)
            {
                movement.enabled = true;
            }
            movement.MakeMove(move);
        }

        if (Input.GetButtonDown("Jump"))
        {
            movement.MakeJump();
        }
    }
}
