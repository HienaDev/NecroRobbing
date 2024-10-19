using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private BoneType dropType;
    [SerializeField] private float displaceObj;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            BoneSetup boneBase = eventData.pointerDrag.GetComponent<BoneSetup>();
            Vector3  pos = GetComponent<RectTransform>().anchoredPosition;
            if (boneBase.BoneType == dropType)
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            else
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(pos.x + displaceObj,pos.y - displaceObj,0f);
        }
    }
}
