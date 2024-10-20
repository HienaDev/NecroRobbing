using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject bonePrefab;
    private Canvas canvas;
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject newBone = Instantiate(bonePrefab,canvas.transform);
        newBone.GetComponent<BoneSetup>().BoneBase = boneBase;
    }
}
