using UnityEngine;
using UnityEngine.Tilemaps;
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

    private int currentTool = 0;

    [SerializeField] private int shovelSize = 3;
    public int ShovelSize { get { return shovelSize; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = 0;
            currentPosition = new Vector3Int(20, 20, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTool = 1;
            currentPosition = new Vector3Int(20, 20, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTool = 2;
            currentPosition = new Vector3Int(20, 20, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTool = 3;
            currentPosition = new Vector3Int(20, 20, 0);
        }
    }

    private void FixedUpdate()
    {
 

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = displayTilemap.WorldToCell(worldPoint);

        //Debug.Log(position);

        if ((currentPosition != position))
        {
            currentPosition = position;
            //Debug.Log("trying to change");
            foreach (Vector3Int vector in changedTiles)
            {
                displayTilemap.SetTile(vector, null);
            }

            changedTiles.Clear();

            switch(currentTool)
            {
                case 0:
                    Hand(currentPosition);
                    break;
                case 1:
                    Brush(currentPosition);
                    break;
                case 2:
                    Spell(currentPosition);
                    break;
                case 3:
                    Shovel(currentPosition);
                    break;
                default:
                    break;
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

                if(i == 0 && j == 0)
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
