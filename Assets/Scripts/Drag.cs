using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    
    private CanvasGroup gCanvas;
    private RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        gCanvas = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventDrag)
    {
        gCanvas.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        gCanvas.blocksRaycasts = true;
    }
    
}
