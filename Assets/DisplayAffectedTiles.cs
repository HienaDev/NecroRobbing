using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Security.Cryptography;

public class DisplayAffectedTiles : MonoBehaviour
{
    [SerializeField] private Tilemap displayTilemap;
    [SerializeField] private Tile blankTile;
    private List<Vector3Int> changedTiles = new List<Vector3Int>();
    [SerializeField] private Tile handTile;

    private Vector3Int currentPosition = new Vector3Int(20, 20, 0);

    private int currentTool = 0;

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

            switch(currentTool)
            {
                case 0:
                    displayTilemap.SetTileFlags(currentPosition, TileFlags.None);
                    displayTilemap.SetTile(currentPosition, handTile);
                    changedTiles.Add(currentPosition);
                    break;
                case 1:
                    displayTilemap.SetTileFlags(currentPosition, TileFlags.None);
                    displayTilemap.SetTile(currentPosition, blankTile);
                    changedTiles.Add(currentPosition);
                    break;
                case 2:
                    int addToValue = 0;
                    int increment = 1;

                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -addToValue;  j < addToValue + 1; j++)
                        {
                            Vector3Int currentPositionWithOffset = currentPosition + new Vector3Int(i, j, 0);
                            displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                            displayTilemap.SetTile(currentPositionWithOffset, blankTile);
                            changedTiles.Add(currentPositionWithOffset);
                        }
                        if (i == 0)
                            increment *= -1;

                        addToValue += increment;

                        
                    }
                    
                    break;
                case 3:
                    addToValue = 0;
                    increment = 1;

                    for (int i = -2; i < 3; i++)
                    {
                        for (int j = -addToValue; j < addToValue + 1; j++)
                        {
                            Vector3Int currentPositionWithOffset = currentPosition + new Vector3Int(i, j, 0);
                            displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                            displayTilemap.SetTile(currentPositionWithOffset, blankTile);
                            changedTiles.Add(currentPositionWithOffset);
                        }
                        if (i == 0)
                            increment *= -1;

                        addToValue += increment;


                    }
                    break;
                default:
                    break;
            }

            
        }




    }
}
