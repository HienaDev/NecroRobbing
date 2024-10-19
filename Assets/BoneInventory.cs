using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BoneInventory : MonoBehaviour
{

    private List<BoneBase> inventory = new List<BoneBase>();
    public List<BoneBase> Inventory { get { return inventory; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(BoneBase b)
    {
        inventory.Add(b);
    }
}
