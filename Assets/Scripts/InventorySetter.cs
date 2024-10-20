using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySetter : MonoBehaviour
{
    [SerializeField] private BoneType boneType;
    public BoneType BoneType { get { return boneType; } }
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

        foreach(InventorySlot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].GetComponentInChildren<Image>().sprite = inventory[i].BoneSprite;
            slots[i].GetComponentInChildren<Image>().color = new Color(1f, 1f, 1f, 1f);
            slots[i].GetComponent<InventorySlot>().BoneBase = inventory[i];
        }

    }

    public void UpdateInventory()
    {

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

        foreach (InventorySlot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].GetComponentInChildren<Image>().sprite = inventory[i].BoneSprite;
            slots[i].GetComponentInChildren<Image>().color = new Color(1f, 1f, 1f, 1f);
            slots[i].GetComponent<InventorySlot>().BoneBase = inventory[i];
        }
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
