using UnityEngine;

public class GoToSummoning : MonoBehaviour
{

    [SerializeField] private GameObject graveRobbing;
    [SerializeField] private GameObject summoning;
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private TilesGenerator tileGenerator;

    private CheckIfPlayerInside checkScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkScript = GetComponent<CheckIfPlayerInside>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkScript.PlayerInside)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                inventory.AddInventory(tileGenerator.BoneInventory);
                graveRobbing.SetActive(false);
                summoning.SetActive(true);
            }
        }
    }
}
