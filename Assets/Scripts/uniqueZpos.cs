using UnityEngine;

public class uniqueZpos : MonoBehaviour
{
    private float signatureZ;
    // Start is called before the first frame update
    void Awake()
    {
        signatureZ = Random.value;
        if (CompareTag("Player"))
        {
            signatureZ *= -1f;
        }
    }

    private void LateUpdate()
    {
        if(transform.position.z != signatureZ)
        {
            Vector3 posAux = transform.position;
            posAux.z = signatureZ;
            transform.position = posAux;
        }
    }

}
