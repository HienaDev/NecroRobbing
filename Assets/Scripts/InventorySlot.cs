using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject bonePrefab;
    private Canvas canvas;
    int index;
    private BoneBase boneBase;
    public BoneBase BoneBase
    {
        get => boneBase;

        set
        {
            boneBase = value;
        }
    }
    void Start()
    {
        canvas = FindFirstObjectByType<Canvas>();
        index = transform.GetSiblingIndex();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (boneBase != null)
        {
            GameObject newBone = Instantiate(bonePrefab,canvas.transform);
            newBone.GetComponent<BoneSetup>().BoneBase = boneBase;
            GetComponentInParent<InventorySetter>().ResetInventory(index);
        }
    }
}
