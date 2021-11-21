using UnityEngine;

public class movement2D : MonoBehaviour
{
    private static float powerJump = 10f;
    private float ghostJump = 0.1f;
    private bool canMakeMovement = true;
    private float multSpeed = 1f;
    //[SerializeField]
    private bool canJump = true, canTurn = true;
    [SerializeField]
    private float maxVelocity = 5;
    private Vector2 direSpeedGo = Vector2.zero;
    private Rigidbody2D body2D;
    private Collider2D coll2D = null, collAux = null;
    private bool flying = false;
    private float jumpingCount = 0f;
    //[SerializeField]
    private bool obstacleDown = true, obstacleUp = false, obstacleRight = false, obstacleLeft = false;
    private animatorControll2D animatorControll;
    //[SerializeField]
    private float angZ = 0f;
    private Vector2 oldVelocity = Vector2.zero, goToVelocity;
    private enum changeVelocity { keep, wait, swicht};
    private changeVelocity stateVelocity = changeVelocity.keep;

    // Start is called before the first frame update
    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        body2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        coll2D = GetComponent<Collider2D>();
        animatorControll = GetComponent<animatorControll2D>();
    }

    public void SetCollAux(Collider2D coll)
    {
        collAux = coll;
    }

    public bool GetObstacle(Vector2 dire)
    {
        if (dire.x > 0f)
        {
            return obstacleRight;
        }
        else if (dire.x < 0f)
        {
            return obstacleLeft;
        }
        else if (dire.y > 0f)
        {
            return obstacleUp;
        }

        return obstacleDown;
    }

    public float GetMaxVelocityNow()
    {
        return multSpeed * maxVelocity;
    }

    public animatorControll2D GetAnimaControll()
    {
        return animatorControll;
    }

    public Collider2D GetCollider()
    {       
        return coll2D;
    }

    public void SetMultSpeed(float value)
    {
        multSpeed = value;
    }

    public void SetCanJump(bool can)
    {
        canJump = can;
    }

    public void SetCanTurn(bool can)
    {
        canTurn = can;
    }

    public void SetCanMove(bool can)
    {
        /*if (CompareTag("Player"))
            Debug.Log(can+" "+name);*/
        canMakeMovement = can;
        if (!can)
        {
            body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void SetGravity(float value)
    {
        body2D.gravityScale = value;
        if (value == 0f)
        {
            body2D.velocity = Vector2.right * body2D.velocity.x;
        }
    }

    private void CheckObstacles(ContactPoint2D point2D)
    {
        if (!obstacleDown)
        {
            obstacleDown = point2D.normal.y > 0.75f;
        }

        if (!obstacleLeft)
        {
            obstacleLeft = point2D.normal.x > 0.75f;
        }

        if (!obstacleRight)
        {
            obstacleRight = point2D.normal.x < -0.75f;
        }

        if (!obstacleUp)
        {
            obstacleUp = point2D.normal.y < -0.75f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stateVelocity == changeVelocity.wait)
        {
            stateVelocity = changeVelocity.swicht;
            if (goToVelocity.y > 0f)
            {
                if (obstacleRight || obstacleLeft)
                {
                    if (obstacleRight)
                    {
                        transform.position += Vector3.left / 16f;
                    }
                    else if (obstacleLeft)
                    {
                        transform.position += Vector3.right / 16f;
                    }
                }
            }
        }else if(stateVelocity == changeVelocity.swicht)
        {
            stateVelocity = changeVelocity.keep;
            body2D.velocity = goToVelocity;
        }

            oldVelocity = body2D.velocity;

        ContactPoint2D[] contactPoints = new ContactPoint2D[8];
        int maxContact = coll2D.GetContacts(contactPoints);
        obstacleDown = false;
        obstacleLeft = false;
        obstacleRight = false;
        obstacleUp = false;
        for(int i=0;i<maxContact; i++)
        {
            PlatformEffector2D effector2D = contactPoints[i].collider.GetComponent<PlatformEffector2D>();

            bool dontCount = false;
            if (effector2D)
            {
                Vector2 v2Aux = Quaternion.Euler(Vector3.forward * effector2D.rotationalOffset) * Vector2.up;
                float ang = Vector2.SignedAngle(v2Aux, contactPoints[i].normal), angSurface = effector2D.surfaceArc / 2f;
                if(ang*ang >= angSurface * angSurface)
                {
                    dontCount = true;
                }
            }

            if (!dontCount)
            {
                CheckObstacles(contactPoints[i]);
            }
        }

        if (collAux && collAux.enabled)
        {
            contactPoints = new ContactPoint2D[8];
            maxContact = collAux.GetContacts(contactPoints);

            for (int i = 0; i < maxContact; i++)
            {
                PlatformEffector2D effector2D = contactPoints[i].collider.GetComponent<PlatformEffector2D>();

                bool dontCount = false;
                if (effector2D)
                {
                    Vector2 v2Aux = Quaternion.Euler(Vector3.forward * effector2D.rotationalOffset) * Vector2.up;
                    float ang = Vector2.SignedAngle(v2Aux, contactPoints[i].normal), angSurface = effector2D.surfaceArc / 2f;
                    if (ang * ang >= angSurface * angSurface)
                    {
                        dontCount = true;
                    }
                }

                if (!dontCount)
                {
                    CheckObstacles(contactPoints[i]);
                }
            }
        }

        if (canMakeMovement)
        {         
            if (coll2D.sharedMaterial != repository.repositoryX.physicsMaterialCharaterDafault)
            {
                coll2D.sharedMaterial = repository.repositoryX.physicsMaterialCharaterDafault;
            }

            Vector2 veloAux = direSpeedGo;
            if (obstacleDown)
            {
                veloAux = Quaternion.Euler(Vector3.forward * angZ) * veloAux;
                if (transform.eulerAngles.y == 180f)
                {
                    veloAux.y *= -1f;
                }
            }
            //Debug.Log(direSpeedGo);
            if (direSpeedGo.sqrMagnitude > 0f)
            {
                Turn(direSpeedGo.x > 0f);

                if (flying)
                {
                    body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    if (obstacleDown && jumpingCount <= 0f)
                    {
                        if (veloAux.y != 0f)
                        {
                            body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                        }
                        else
                        {
                            body2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                        }
                    }
                    else
                    {                 
                        body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                        if (veloAux.x > 0f)
                        {
                            if (obstacleRight)
                            {
                                veloAux.x = 0f;
                            }
                        }
                        else if(veloAux.x < 0f)
                        {
                            if (obstacleLeft)
                            {
                                veloAux.x = 0f;
                            }
                        }
                        veloAux.y = body2D.velocity.y;
                    }
                }
            }
            else
            {
                if (flying)
                {
                    body2D.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                else
                {
                    if (obstacleDown && jumpingCount <= 0f)
                    {
                        body2D.constraints = RigidbodyConstraints2D.FreezeAll;
                    }
                    else
                    {
                        body2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                        veloAux.y = body2D.velocity.y;
                    }
                }
            }
            //Debug.Log(veloAux);
            body2D.velocity = veloAux;
        }
        else if (coll2D.sharedMaterial != repository.repositoryX.physicsMaterialDontMove)
        {
            coll2D.sharedMaterial = repository.repositoryX.physicsMaterialDontMove;
        }

        if (jumpingCount > 0f)
        {
            jumpingCount -= Time.fixedDeltaTime;
        }

        if (ghostJump > 0f)
        {
            ghostJump -= Time.fixedDeltaTime;
        }

        if (obstacleDown)
        {
            if (ghostJump != 0.1f)
            {
                ghostJump = 0.1f;
            }
            //Calcular angulo de movimento
            Vector2 vector2Aux = transform.position, vector2Side = Vector2.right;
            Vector2 posOrig = coll2D.bounds.center + Vector3.down * (coll2D.bounds.extents.y - 0.5f);
            if (transform.eulerAngles.y == 0f)
            {
                posOrig += Vector2.right * coll2D.bounds.extents.x;
            }
            else
            {
                posOrig -= Vector2.right * coll2D.bounds.extents.x;
                vector2Side *= -1f;
            }

            Vector2 vector2Aux2 = transform.position;
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(posOrig, Vector2.down, 1.5f, repository.repositoryX.GetLayerMaskGround());
            for(int i=0; i<hits2D.Length; i++)
            {
                if (i == 0)
                {
                    vector2Aux2 = hits2D[i].point;
                }
                else
                {
                    float deltaYDist1 = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * vector2Aux2.y);
                    float deltaYDist2 = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * hits2D[i].point.y);

                    if (deltaYDist1 > deltaYDist2)
                    {
                        vector2Aux2 = hits2D[i].point;
                    }
                }
            }

            angZ = Vector2.SignedAngle(vector2Side, vector2Aux2 - vector2Aux);
            if (transform.eulerAngles.y == 180f)
            {
                angZ *= -1f;
            }
        }
        else if(angZ != 0f)
        {
            angZ = 0f;
        }
    }

    private void LateUpdate()
    {
        if (animatorControll)
        {
            if (obstacleDown || ghostJump > 0f)
            {
                animatorControll.NotInGround(body2D.velocity.y <= 0f, true);
                animatorControll.WalkAnimation(body2D.velocity.sqrMagnitude > 0f && direSpeedGo.sqrMagnitude > 0f);
            }
            else
            {
                animatorControll.NotInGround(body2D.velocity.y <= 0f, false);
            }
        }
    }

    public void MakeMove(Vector2 dire)
    {
        if (canMakeMovement)
        {
            if (!flying)
            {
                dire.y = 0f;
            }
            dire.Normalize();

            if (dire.x > 0f && ((!canTurn && !auxiliary.IsRightTurn(transform)) || obstacleRight))
            {
                dire.x = 0f;
            }
            else if (dire.x < 0f && ((!canTurn && auxiliary.IsRightTurn(transform)) || obstacleLeft))
            {
                dire.x = 0f;
            }

            direSpeedGo = dire * maxVelocity * multSpeed;
            /*if(!CompareTag("Player"))
            Debug.Log(direSpeedGo);*/

            if(dire.x != 0f && canTurn)
            {
                Turn(dire.x > 0f);
            }
        }
    }

    public bool IsMove()
    {
        return direSpeedGo.sqrMagnitude > 0f;
    }

    public void MakeJump()
    {
        if (canMakeMovement && jumpingCount <= 0f && obstacleDown && canJump)
        {
            jumpingCount = 0.1f;
            Vector2 veloAux = body2D.velocity;
            veloAux.y = powerJump;
            if (veloAux.x > 0f)
            {
                if (obstacleRight)
                {
                    veloAux.x = 1f;
                }
            }
            else if (veloAux.x < 0f)
            {
                if (obstacleLeft)
                {
                    veloAux.x =- 1f;
                }
            }

            stateVelocity = changeVelocity.wait;
            goToVelocity = veloAux;
            //body2D.velocity = veloAux;
        }
    }

    public void AddForceInBody(Vector2 force)
    {
        SetCanMove(false);

        stateVelocity = changeVelocity.wait;
        goToVelocity = force;
        //body2D.velocity = force;
    }

    public void StopMove()
    {
        direSpeedGo = Vector2.zero;

        if (flying)
        {
            body2D.velocity = Vector2.zero;
        }
        else
        {
            Vector2 v = body2D.velocity;
            v.x = 0f;
            body2D.velocity = v;
        }
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return body2D;
    }

    public void Turn(bool right, bool forced = false)
    {
        if ((canTurn && canMakeMovement) || forced)
        {
            /*if(!CompareTag("Player"))
            Debug.Log(right+" "+name);*/

            auxiliary.TurnTransform(transform, right);
        }
    }

    public float DistancieGround()
    {
        if (obstacleDown)
        {
            return 0f;
        }

        RaycastHit2D r = Physics2D.Raycast(transform.position, Vector2.down, 10f,repository.repositoryX.GetLayerMaskGround());

        if (r.collider)
        {
            return r.distance;
        }

        return 10f;
    }

    public bool IsJumpAnima()
    {
        return body2D.velocity.y > 0f;
    }

    public float AngGround()
    {
        float v = angZ;
        if(transform.eulerAngles.y == 180f)
        {
            v *= -1f;
        }
        return v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canMakeMovement && collision.contacts[0].normal.y > 0f)
        {
            Vector2 speedX = oldVelocity;
            speedX.y = 0f;
            body2D.velocity = speedX;
        }
    }
}
