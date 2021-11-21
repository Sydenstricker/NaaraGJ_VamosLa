using UnityEngine;

public class auxiliary : MonoBehaviour
{
    [SerializeField]
    private GameObject objInv = null;
    private bool started = false;
    public Vector2 offsetObj;

    private void OnEnable()
    {
        if (started)
        {
            if (objInv)
            {
                GameObject obj = repository.repositoryX.GetRespawObj(objInv);
                obj.transform.SetParent(transform);
                //objInv.transform.eulerAngles = Vector3.zero;
                obj.transform.localPosition = offsetObj;
                obj.transform.SetParent(repository.repositoryX.transform);
                obj.SetActive(true);
            }
        }
        else if (objInv)
        {
            repository.repositoryX.AddResapwObj(objInv);
            started = true;
        }
    }

    public static void TurnTransform(Transform tr, bool right)
    {
        if (right)
        {
            if (!IsRightTurn(tr))
            {
                Vector3 vectorAngle = tr.eulerAngles;
                vectorAngle.y = 0f;
                tr.eulerAngles = vectorAngle;
            }
        }
        else if (tr.eulerAngles.y != 180f)
        {
            Vector3 vectorAngle = tr.eulerAngles;
            vectorAngle.y = 180f;
            tr.eulerAngles = vectorAngle;
        }
    }

    public static bool IsRightTurn(Transform t)
    {
        return t.eulerAngles.y == 0;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
