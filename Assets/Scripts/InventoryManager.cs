using System.Collections.Generic;
using System.Linq;
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
    void Start()
    {
        AddInventory(testInventory);
    }
    public void AddInventory(List<BoneBase> inventory)
    {
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
}
