using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject bonePrefab;
    private Canvas canvas;
    int index;
    private BoneBase boneBase;

    private SummonCheck summonCheck;
    private InventorySetter inventorySetter;
    private InventoryManager inventoryManager;


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

        summonCheck = FindFirstObjectByType<SummonCheck>();
        inventorySetter = GetComponentInParent<InventorySetter>();
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (boneBase != null)
        {            

            switch (inventorySetter.BoneType)
            {
                case BoneType.Head:

                    BoneBase bone = summonCheck.GetHead();

                    //if(bone != null)
                 //   {

                        //inventoryManager.AddBackToInventory(bone);
                    //}
                        

                    summonCheck.SetHead(boneBase);
                    
                    break;

                case BoneType.Arm:

                    if (!summonCheck.leftArm)
                    {
                        bone = summonCheck.GetLeftArm();

                        //if (bone != null)
                        //inventoryManager.AddBackToInventory(bone);
                        Debug.Log("no left arm");
                        Debug.Log("before: " + summonCheck.leftArm);
                        summonCheck.leftArm = true;
                        Debug.Log("after: " + summonCheck.leftArm);
                        summonCheck.SetLeftArm(boneBase);
                        
                    }
                    else
                    {
                        bone = summonCheck.GetRightArm();

                        //if (bone != null)
                        //inventoryManager.AddBackToInventory(bone);

                        Debug.Log("has left arm");
                        summonCheck.leftArm = false;

                        summonCheck.SetRightArm(boneBase);
                        
                    }
                    break;

                case BoneType.Torso:

                    bone = summonCheck.GetTorso();

                    //if (bone != null)
                        //inventoryManager.AddBackToInventory(bone);

                    summonCheck.SetTorso(boneBase);
                    
                    break;


                case BoneType.Leg:

                    if (!summonCheck.leftLeg)
                    {
                        bone = summonCheck.GetLeftLeg();

                        //if (bone != null)
                            //inventoryManager.AddBackToInventory(bone);

                        summonCheck.leftLeg = true;

                        summonCheck.SetLeftLeg(boneBase);
                        

                    }
                    else
                    {
                        bone = summonCheck.GetRightLeg();

                        //if (bone != null)
                            //inventoryManager.AddBackToInventory(bone);

                        summonCheck.leftLeg = false;

                        summonCheck.SetRightLeg(boneBase);
                        
                    }
                    break;
            }

            inventorySetter.UpdateInventory();
        }
    }
}
