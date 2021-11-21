using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    public Vector2 effectParallax;
    private Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posLocalFinal = transform.localPosition;
        float repetition;

        if (effectParallax.x != 0f)
        {
            float dist = Camera.main.transform.position.x * -effectParallax.x;
            repetition = dist / (size.x / 3f);
            posLocalFinal.x = (repetition - Mathf.FloorToInt(repetition)) * size.x / 3f;
        }

        if (effectParallax.y != 0f)
        {
            float dist = Camera.main.transform.position.y * -effectParallax.y;
            repetition = dist / (size.y / 3f);
            posLocalFinal.y = (repetition - Mathf.FloorToInt(repetition)) * size.y / 3f;
        }

            transform.localPosition = posLocalFinal;
    }
}
