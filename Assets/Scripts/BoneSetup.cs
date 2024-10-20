using UnityEngine;
using UnityEngine.UI;

public class BoneSetup : MonoBehaviour
{
    [SerializeField] private BoneBase boneBase;
    public BoneBase BoneBase
    {
        get => boneBase;

        set
        {
            boneBase = value;
        }
    }
    private Image image;
    private BoneType boneType;
    public BoneType BoneType => boneType;
    private float boneSize;
    private float bonePower;
    private RectTransform rectTrans;
    private Vector3 initialPos;
    public Vector3 InitialPos => initialPos;
    void Start()
    {
        image = GetComponent<Image>();
        rectTrans = GetComponent<RectTransform>();
        image.sprite = boneBase.BoneSprite;
        Vector3 curScale = image.sprite.rect.size;
        rectTrans.sizeDelta = new Vector3(curScale.x,curScale.y,1f);
        rectTrans.localScale = new Vector3(3f,3f,1f);
        boneType = boneBase.BoneType;
        boneSize = boneBase.BoneSize;
        bonePower = boneBase.PowerLevel;
        initialPos = rectTrans.anchoredPosition;
    }
    void Update()
    {
        
    }
}
