using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<BoneBase> skullInventory;
    private List<BoneBase> legInventory;
    private List<BoneBase> toraxInventory;
    private List<BoneBase> armInventory;
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
