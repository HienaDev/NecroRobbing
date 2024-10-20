using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySetter : MonoBehaviour
{
    [SerializeField] BoneType boneType;
    private List<BoneBase> inventory;
    private InventoryManager inventoryManager;
    private int i = 0;

    void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();

        switch (boneType)
        {
            case BoneType.Head:
                inventory = inventoryManager.SkullInventory;
                break;
            case BoneType.Arm:
                inventory = inventoryManager.ArmInventory;
                break;
            case BoneType.Torso:
                inventory = inventoryManager.ToraxInventory;
                break;
            case BoneType.Leg:
                inventory = inventoryManager.LegInventory;
                break;
        }
        

        foreach (BoneBase bone in inventory)
        {
            GameObject slot = transform.GetChild(i).gameObject;
            slot.GetComponentInChildren<Image>().sprite = bone.BoneSprite;
            slot.GetComponentInChildren<Image>().color = new Color(1f,1f,1f,1f);
            slot.GetComponent<InventorySlot>().BoneBase = bone;
            i++;
        }
    }
    public void ResetInventory()
    {
        
    }
}
