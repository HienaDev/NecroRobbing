using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<BoneBase> testInventory;
    private List<BoneBase> skullInventory = new List<BoneBase>();
    public List<BoneBase> SkullInventory => skullInventory;
    private List<BoneBase> legInventory = new List<BoneBase>();
    public List<BoneBase> LegInventory => legInventory;
    private List<BoneBase> toraxInventory = new List<BoneBase>();
    public List<BoneBase> ToraxInventory => toraxInventory;
    private List<BoneBase> armInventory = new List<BoneBase>();
    public List<BoneBase> ArmInventory => armInventory;



    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
            AddInventory(testInventory);
    }

    public void AddInventory(List<BoneBase> inventory)
    {
        skullInventory = new List<BoneBase>();

        legInventory = new List<BoneBase>();

        toraxInventory = new List<BoneBase>();

        armInventory = new List<BoneBase>();

        foreach (BoneBase bone in inventory)
        {
            switch (bone.BoneType)
            {
                case BoneType.Head:
                    skullInventory.Add(bone);
                    break;
                case BoneType.Arm:
                    armInventory.Add(bone);
                    break;
                case BoneType.Torso:
                    toraxInventory.Add(bone);
                    break;
                case BoneType.Leg:
                    legInventory.Add(bone);
                    break;
            }
        }
    }

    public void AddBackToInventory(BoneBase bone)
    {
        Debug.Log("Add " + bone.name + " back");
        Debug.Log("test inventory count before: " + testInventory.Count);
        testInventory.Add(bone);
        Debug.Log("test inventory count after: " + testInventory.Count);
        AddInventory(testInventory);

    }

    public void RemoveFromInventory(BoneBase bone)
    {
        testInventory.Remove(bone);
        AddInventory(testInventory);
    }
}
