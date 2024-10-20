using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.XR;

public class DisplayAffectedTiles : MonoBehaviour
{
    [SerializeField] private Tilemap displayTilemap;
    [SerializeField] private Tile greenTile;
    [SerializeField] private Tile yellowTile;
    [SerializeField] private Tile redTile;
    private List<Vector3Int> changedTiles = new List<Vector3Int>();
    [SerializeField] private Tile handTile;

    private Vector3Int currentPosition = new Vector3Int(20, 20, 0);

    private int currentTool = 3;

    [SerializeField] private int shovelSize = 3;
    public int ShovelSize { get { return shovelSize; } }

    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject spell;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject hand;
    private GameObject currentCursor;

    [SerializeField] private ClickOnTiles clickOnTilesScript;

    private SoundManager soundManager;


    private void OnEnable()
    {
        Cursor.visible = false;
        currentCursor = hand;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = GetComponent<SoundManager>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateHand();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateBrush();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSpell();

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateShovel();
        }
    }

    public void ActivateHand()
    {

        currentTool = 3;
        currentCursor.SetActive(false);
        currentCursor = hand;
        hand.SetActive(true);
        currentPosition = new Vector3Int(20, 20, 0);
        clickOnTilesScript.ActivateHand();
    }

    public void ActivateBrush()
    {
        soundManager.PlayBlockBreakingSound();
        currentTool = 2;
        currentCursor.SetActive(false);
        currentCursor = brush;
        brush.SetActive(true);
        currentPosition = new Vector3Int(20, 20, 0);
        clickOnTilesScript.ActivateBrush();
    }

    public void ActivateSpell()
    {
        soundManager.PlayPickUpSound();
        currentTool = 1;
        currentCursor.SetActive(false);
        currentCursor = spell;
        spell.SetActive(true);
        currentPosition = new Vector3Int(20, 20, 0);
        clickOnTilesScript.ActivateSpell();
    }

    public void ActivateShovel()
    {
        soundManager.PlayStepsGravelSound();
        currentTool = 0;
        currentCursor.SetActive(false);
        currentCursor = shovel;
        shovel.SetActive(true);
        currentPosition = new Vector3Int(20, 20, 0);
        clickOnTilesScript.ActivateShovel();

    }

    private void FixedUpdate()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = displayTilemap.WorldToCell(worldPoint);

        Debug.Log(position);

        if ((currentPosition != position))
        {
            currentPosition = position;
            //Debug.Log("trying to change");
            foreach (Vector3Int vector in changedTiles)
            {
                displayTilemap.SetTile(vector, null);
            }

            changedTiles.Clear();
            if (position.x <= 4 && position.x >= -5 && position.y >= -5 && position.y <= 4)
            {
                switch (currentTool)
                {
                    case 0:
                        Shovel(currentPosition);
                        break;
                    case 1:
                        Spell(currentPosition);
                        break;
                    case 2:
                        Brush(currentPosition);
                        break;
                    case 3:
                        Hand(currentPosition);
                        break;
                    default:
                        break;
                }
            }



        }

    }

    private void Hand(Vector3Int currentPos)
    {
        displayTilemap.SetTileFlags(currentPos, TileFlags.None);
        displayTilemap.SetTile(currentPos, handTile);
        changedTiles.Add(currentPos);
    }

    private void Brush(Vector3Int currentPos)
    {
        displayTilemap.SetTileFlags(currentPos, TileFlags.None);
        displayTilemap.SetTile(currentPos, greenTile);
        changedTiles.Add(currentPos);
    }

    private void Spell(Vector3Int currentPos)
    {
        int addToValue = 0;
        int increment = 1;


        for (int i = -1; i < 2; i++)
        {
            for (int j = -addToValue; j < addToValue + 1; j++)
            {
                Vector3Int currentPositionWithOffset = currentPos + new Vector3Int(i, j, 0);
                displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                changedTiles.Add(currentPositionWithOffset);

                if (i == 0 && j == 0)
                {
                    displayTilemap.SetTile(currentPositionWithOffset, greenTile);
                }
                else
                {
                    displayTilemap.SetTile(currentPositionWithOffset, yellowTile);
                }
            }
            if (i == 0)
                increment *= -1;

            addToValue += increment;


        }
    }

    private void Shovel(Vector3Int currentPos)
    {

        for (int i = -shovelSize + 1; i < shovelSize; i++)
        {
            for (int j = -shovelSize + 1; j < shovelSize; j++)
            {
                Vector3Int currentPositionWithOffset = currentPos + new Vector3Int(i, j, 0);
                displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                changedTiles.Add(currentPositionWithOffset);

                if (i == 0 && j == 0)
                {
                    displayTilemap.SetTile(currentPositionWithOffset, redTile);
                }
                else if (i >= -1 && i <= 1 && j >= -1 && j <= 1)
                {
                    displayTilemap.SetTile(currentPositionWithOffset, yellowTile);
                }
                else
                {
                    displayTilemap.SetTile(currentPositionWithOffset, greenTile);
                }
            }
        }
    }
}
