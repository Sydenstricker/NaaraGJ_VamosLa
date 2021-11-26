using UnityEngine;
using UnityEngine.UI;

public class itensCollectInf : MonoBehaviour
{
    public static itensCollectInf itensCollectX = null;
    [SerializeField]
    private Image imageItem = null;
    private Text textDescrition;
    private float sizeMaxImage;

    // Start is called before the first frame update
    void Awake()
    {
        itensCollectX = this;
        textDescrition = GetComponentInChildren<Text>();
        sizeMaxImage = imageItem.rectTransform.sizeDelta.x;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void CollectImportantItem(Sprite spriteItem, string descrition)
    {
        gameObject.SetActive(true);
        textDescrition.text = descrition;
        imageItem.sprite = spriteItem;
        imageItem.SetNativeSize();
        float sizeAux = imageItem.rectTransform.sizeDelta.x;
        if (sizeAux < imageItem.rectTransform.sizeDelta.y)
        {
            sizeAux = imageItem.rectTransform.sizeDelta.y;
        }
        float multSize = sizeMaxImage / sizeAux;

        imageItem.rectTransform.sizeDelta = imageItem.rectTransform.sizeDelta * multSize;
        Time.timeScale = 0f;
    }
}
