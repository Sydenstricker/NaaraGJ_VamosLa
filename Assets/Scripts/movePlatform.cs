using UnityEngine;

public class movePlatform : MonoBehaviour
{
    private static float speedConstant = 3f;
    [SerializeField]
    private Transform[] transformsPositions = null;
    private int idGo = 0;
    private float countGoTimeGo = 0f, timeToGo = 1f;
    private Vector3 posAux;
    // Start is called before the first frame update
    void Start()
    {
        if (transformsPositions != null && transformsPositions.Length > 0)
        {
            transform.position = transformsPositions[idGo].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transformsPositions != null)
        {
            if(transformsPositions[idGo].position != transform.position)
            {
                countGoTimeGo += Time.deltaTime / timeToGo;
                Vector3 posGo = Vector3.Lerp(posAux, transformsPositions[idGo].position, countGoTimeGo);
                transform.position = posGo;
            }
        }
    }

    public void MovePlatform(int add)
    {
        idGo += add;
        if (idGo >= transformsPositions.Length)
        {
            idGo = 0;
        }
        else if(idGo<0)
        {
            idGo = transformsPositions.Length - 1;
        }

        float dist = Vector2.Distance(transform.position, transformsPositions[idGo].position);
        countGoTimeGo = 0f;
        timeToGo = dist / speedConstant;
        posAux = transform.position;
    }

    public bool IsInFinalLocal()
    {
        return transformsPositions == null || transformsPositions[idGo].position == transform.position;
    }
}
