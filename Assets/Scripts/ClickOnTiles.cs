using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class ClickOnTiles : MonoBehaviour
{

    [System.Serializable]
    public class Tool
    {
        public Vector3[] toolConfig;
        public Tile[] tilesInOrder;
    }


    [SerializeField] private Tilemap[] tilemaps;
    private Tilemap currentTilemap = null;
    private Vector3Int currentPos = Vector3Int.zero;

    [Header("Tools"), SerializeField] private Tool[] tools;
    private int currentTool = 0;

    [Header("GRID"), SerializeField] private TilesGenerator tilesGeneratorScript;

    int[,] bonesGrid;
    int[,] dirtGrid;

    [SerializeField] private DisplayAffectedTiles displayScript;

    [SerializeField] private GameObject brushButtonON;
    [SerializeField] private GameObject brushButtonOFF;

    [SerializeField] private GameObject shovelButtonON;
    [SerializeField] private GameObject shovelButtonOFF;

    [SerializeField] private GameObject spellButtonON;
    [SerializeField] private GameObject spellButtonOFF;

    [SerializeField] private GameObject handButtonON;
    [SerializeField] private GameObject handButtonOFF;

    private GameObject currentToolUI;

    [SerializeField] private Image meterFill;
    [SerializeField] private float graveDurability = 20;
    private float currentDurability = 20;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private GameObject transition;

    [SerializeField] private GameObject[] inventorySlotsRobbing;

    private SoundManager soundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
    }

    private void OnEnable()
    {
        currentToolUI = handButtonON;

        currentDurability = graveDurability;

        meterFill.fillAmount = currentDurability / graveDurability;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    ActivateHand();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    ActivateBrush();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    ActivateSpell();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    ActivateShovel();
        //}

        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = tilemaps[0].WorldToCell(worldPoint);


            if (position.x <= 4 && position.x >= -5 && position.y >= -5 && position.y <= 4)
                switch (currentTool)
                {
                    case 0:
                        Shovel(position);
                        soundManager.PlayStepsGravelSound();
                        UpdateGridData();
                        break;
                    case 1:
                        Spell(position);
                        soundManager.PlayMenuSound();
                        UpdateGridData();
                        break;
                    case 2:
                        Brush(position);
                        soundManager.PlayTakePictureSound();
                        UpdateGridData();
                        break;
                    case 3:
                        Hand(position);

                        UpdateGridData();
                        break;
                    default:
                        break;
                }

        }


    }

    public void ActivateHand()
    {
        currentTool = 3;
        currentToolUI.SetActive(false);
        handButtonON.SetActive(true);
        currentToolUI = handButtonON;
    }

    public void ActivateSpell()
    {
        currentTool = 1;
        currentToolUI.SetActive(false);
        spellButtonON.SetActive(true);
        currentToolUI = spellButtonON;
    }

    public void ActivateBrush()
    {
        currentTool = 2;
        currentToolUI.SetActive(false);
        brushButtonON.SetActive(true);
        currentToolUI = brushButtonON;
    }

    public void ActivateShovel()
    {
        currentTool = 0;
        currentToolUI.SetActive(false);
        shovelButtonON.SetActive(true);
        currentToolUI = shovelButtonON;
    }

    private void UpdateMeter(float damage)
    {
        currentDurability -= damage;
        Debug.Log(currentDurability / graveDurability);
        text.text = currentDurability.ToString();
        meterFill.fillAmount = currentDurability / graveDurability;

        if (currentDurability <= 0)
        {
            foreach(GameObject slot in inventorySlotsRobbing)
            {
                slot.SetActive(false);
            }

            for (int i = 0; i < tilesGeneratorScript.BoneInventory.Count; i++)
            {
                if(i < inventorySlotsRobbing.Length)
                {
                    inventorySlotsRobbing[i].SetActive(true);
                    inventorySlotsRobbing[i].GetComponent<Image>().sprite = tilesGeneratorScript.BoneInventory[i].BoneSprite;
                }

            }

            transition.SetActive(true);
        }
    }

    private void Hand(Vector3Int currentPos)
    {
        Debug.Log("x = " + dirtGrid.GetLength(0));
        Debug.Log("y = " + dirtGrid.GetLength(1));
        currentPos += new Vector3Int(dirtGrid.GetLength(0) / 2, dirtGrid.GetLength(1) / 2, 0);

        Debug.Log(currentPos);

        if ((currentPos.x) >= 0 && (currentPos.x) < dirtGrid.GetLength(0) &&
                    (currentPos.y) >= 0 && (currentPos.y) < dirtGrid.GetLength(1))
            if (dirtGrid[currentPos.x, currentPos.y] <= 0)
                dirtGrid[currentPos.x, currentPos.y] = 50;

        UpdateGridData();
    }

    private void Brush(Vector3Int currentPos)
    {
        bool usedDurability = false;

        Debug.Log("x = " + dirtGrid.GetLength(0));
        Debug.Log("y = " + dirtGrid.GetLength(1));
        currentPos += new Vector3Int(dirtGrid.GetLength(0) / 2, dirtGrid.GetLength(1) / 2, 0);

        if ((currentPos.x) >= 0 && (currentPos.x) < dirtGrid.GetLength(0) &&
                    (currentPos.y) >= 0 && (currentPos.y) < dirtGrid.GetLength(1))
            if (dirtGrid[currentPos.x, currentPos.y] == 1)
            {
                if (usedDurability == false)
                {
                    usedDurability = true;
                    UpdateMeter(1);
                }
                dirtGrid[currentPos.x, currentPos.y] -= 1;
            }


        UpdateGridData();
    }

    private void Spell(Vector3Int currentPos)
    {

        bool usedDurability = false;

        int addToValue = 0;
        int increment = 1;
        currentPos += new Vector3Int(dirtGrid.GetLength(0) / 2, dirtGrid.GetLength(1) / 2, 0);
        for (int i = -1; i < 2; i++)
        {
            for (int j = -addToValue; j < addToValue + 1; j++)
            {
                if ((currentPos.x + i) >= 0 && (currentPos.x + i) < dirtGrid.GetLength(0) &&
                    (currentPos.y + j) >= 0 && (currentPos.y + j) < dirtGrid.GetLength(1))
                {
                    if (usedDurability == false)
                    {
                        usedDurability = true;
                        UpdateMeter(3);
                    }

                    if (i == 0 && j == 0)
                    {
                        dirtGrid[currentPos.x + i, currentPos.y + j] -= 1;
                    }
                    else
                    {
                        dirtGrid[currentPos.x + i, currentPos.y + j] -= 2;
                    }
                }
            }
            if (i == 0)
                increment *= -1;

            addToValue += increment;


        }
    }

    private void Shovel(Vector3Int currentPos)
    {
        bool usedDurability = false;

        currentPos += new Vector3Int(dirtGrid.GetLength(0) / 2, dirtGrid.GetLength(1) / 2, 0);
        for (int i = -displayScript.ShovelSize + 1; i < displayScript.ShovelSize; i++)
        {
            for (int j = -displayScript.ShovelSize + 1; j < displayScript.ShovelSize; j++)
            {

                if ((currentPos.x + i) >= 0 && (currentPos.x + i) < dirtGrid.GetLength(0) &&
                    (currentPos.y + j) >= 0 && (currentPos.y + j) < dirtGrid.GetLength(1))
                {
                    if (usedDurability == false)
                    {
                        usedDurability = true;
                        UpdateMeter(5);
                    }


                    if (i == 0 && j == 0)
                    {
                        dirtGrid[currentPos.x + i, currentPos.y + j] -= 3;
                    }
                    else if (i >= -1 && i <= 1 && j >= -1 && j <= 1)
                    {
                        dirtGrid[currentPos.x + i, currentPos.y + j] -= 2;
                    }
                    else
                    {
                        dirtGrid[currentPos.x + i, currentPos.y + j] -= 1;
                    }

                }

            }
        }

        UpdateGridData();
    }

    public void ReceiveGridData(int[,] dirt, int[,] bones)
    {
        dirtGrid = dirt;
        bonesGrid = bones;
    }

    private void UpdateGridData()
    {
        tilesGeneratorScript.UpdateTiles(dirtGrid, bonesGrid);
    }
}
