using UnityEngine;


public class animatorControll2D : MonoBehaviour
{
    private Animator animator;
    private bool normalState = true, resetTimeTrigger = false;
    private string idAnimaIdle = "Idle", idAnimaWalk = "Walk", idAnimaJump = "Jump", idAnimaFalling = "Falling", animaNow = "Idle";
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        //Debug.Log(animator.GetFloat("Agility"));
    }

    private void SetAnimation(string idAnimation, bool resetTime)
    {
        if (animator.enabled)
        {
            float timeN = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (resetTime || resetTimeTrigger)
            {
                timeN = 0f;
                if (!resetTimeTrigger)
                {
                    resetTimeTrigger = true;
                }
            }

            if (timeN > 1f)
            {
                timeN = timeN - Mathf.Floor(timeN);
            }

            //if(!normalState)
            //Debug.Log(idAnimation+" n "+timeN);
            animaNow = idAnimation;
            animator.Play(idAnimation, 0, timeN);
        }
    }

    private void LateUpdate()
    {
        resetTimeTrigger = false;
    }

    public string GetIdAnimaNow()
    {
        return animaNow;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void WalkAnimation(bool walk)
    {
        if (normalState)
        {
            string idAnima = idAnimaIdle;
            if (walk)
            {
                idAnima = idAnimaWalk;
            }

            if (animaNow != idAnima)
            {
                SetAnimation(idAnima, false);
            }
        }

        if (walk)
        {
            animator.SetFloat("Move", 1f);
        }
        else
        {
            animator.SetFloat("Move", 0f);
        }
    }

    public void NotInGround(bool falling, bool inGround)
    {
        if (inGround)
        {
            animator.SetFloat("In ground", 1f);
        }
        else
        {
            animator.SetFloat("In ground", 0f);

            if (normalState)
            {
                string idAnima = idAnimaJump;
                if (falling)
                {
                    idAnima = idAnimaFalling;
                }

                if (animaNow != idAnima)
                {
                    SetAnimation(idAnima, false);
                }
            }
        }
    }

    public void SetDefaultsAnimation(string idle = "Idle", string walk = "Walk", string jump = "Jump", string falling = "Falling")
    {
        if (idAnimaIdle != "")
        {
            idAnimaIdle = idle;
        }
        else
        {
            idAnimaIdle = "Idle";
        }

        if (idAnimaWalk != "")
        {
            idAnimaWalk = walk;
        }
        else
        {
            idAnimaWalk = "Walk";
        }

        if (idAnimaJump != "")
        {
            idAnimaJump = jump;
        }
        else
        {
            idAnimaJump = "Jump";
        }

        if (idAnimaFalling != "")
        {
            idAnimaFalling = falling;
        }
        else
        {
            idAnimaFalling = "Falling";
        }
    }

    public void SetActionAnimation(string id, bool forced, bool repeat)
    {
        if (normalState || forced)
        {
            if (id != animaNow || repeat)
            {
                //Debug.Log(id);
                normalState = false;
                SetAnimation(id, true);
            }
        }
    }

    public void SetNormalState()
    {
        normalState = true;
    }

    public bool GetNormalState(string idIdle = "Idle")
    {
        return normalState && idAnimaIdle == idIdle;
    }

    public bool GetInGround()
    {
        return animator.GetFloat("In ground") == 1f;

    }
}
