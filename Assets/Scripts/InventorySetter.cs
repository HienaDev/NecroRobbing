using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySetter : MonoBehaviour
{
    [SerializeField] BoneType boneType;
    private List<BoneBase> inventory;
    private InventorySlot[] slots;
    private InventoryManager inventoryManager;
    private int i = 0;

    

    void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
        slots = GetComponentsInChildren<InventorySlot>();

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

        SetInventory();
    }
    private void SetInventory()
    {
        foreach (BoneBase bone in inventory)
        {
            GameObject slot = transform.GetChild(i).gameObject;
            slot.GetComponentInChildren<Image>().sprite = bone.BoneSprite;
            slot.GetComponentInChildren<Image>().color = new Color(1f,1f,1f,1f);
            slot.GetComponent<InventorySlot>().BoneBase = bone;
            i++;
        }
        i = 0;
    }
    public void ResetInventory(int id)
    {
        inventory.RemoveAt(id);
        for(int i = id; i < slots.Length; i++)
        {
            slots[i].BoneBase = null;
            slots[i].gameObject.GetComponent<Image>().sprite = null;
            slots[i].gameObject.GetComponent<Image>().color = new Color(0f,0f,0f,0.5f);
        }
        SetInventory();
    }
}
