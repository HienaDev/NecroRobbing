using UnityEngine;
using UnityEngine.UI;

public class BoneSetup : MonoBehaviour
{
    [SerializeField] private BoneBase boneBase;
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
        image.SetNativeSize();
        Vector3 curScale = rectTrans.localScale;
        rectTrans.localScale = new Vector3(curScale.x*4,curScale.y*4,1f);
        image.sprite = boneBase.BoneSprite;
        boneType = boneBase.BoneType;
        boneSize = boneBase.BoneSize;
        bonePower = boneBase.PowerLevel;
        initialPos = rectTrans.anchoredPosition;
    }
    void Update()
    {
        
    }
}
