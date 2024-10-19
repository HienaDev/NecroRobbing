using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTool = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTool = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTool = 3;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = tilemaps[0].WorldToCell(worldPoint);



            switch (currentTool)
            {
                case 0:
                    //displayTilemap.SetTileFlags(currentPosition, TileFlags.None);
                    //displayTilemap.SetTile(currentPosition, blankTile);
                    //displayTilemap.SetColor(currentPosition, Color.red);
                    //changedTiles.Add(currentPosition);
                    break;
                case 1:
                    //displayTilemap.SetTileFlags(currentPosition, TileFlags.None);
                    //displayTilemap.SetTile(currentPosition, blankTile);
                    //changedTiles.Add(currentPosition);
                    break;
                case 2:
                    int addToValue = 0;
                    int increment = 1;

                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -addToValue; j < addToValue + 1; j++)
                        {
                            //Vector3Int currentPositionWithOffset = currentPosition + new Vector3Int(i, j, 0);
                            //displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                            //displayTilemap.SetTile(currentPositionWithOffset, blankTile);
                            //changedTiles.Add(currentPositionWithOffset);
                        }
                        if (i == 0)
                            increment *= -1;

                        addToValue += increment;


                    }

                    break;
                case 3:
                    Shovel(position);
                    addToValue = 0;
                    increment = 1;

                    for (int i = -2; i < 3; i++)
                    {
                        for (int j = -addToValue; j < addToValue + 1; j++)
                        {
                            //Vector3Int currentPositionWithOffset = currentPosition + new Vector3Int(i, j, 0);
                            //displayTilemap.SetTileFlags(currentPositionWithOffset, TileFlags.None);
                            //displayTilemap.SetTile(currentPositionWithOffset, blankTile);
                            //changedTiles.Add(currentPositionWithOffset);
                        }
                        if (i == 0)
                            increment *= -1;

                        addToValue += increment;


                    }
                    break;
                default:
                    break;
            }

            for (int i = 0; i < tilemaps.Length; i++)
            {
                //Vector3Int position = tilemaps[i].WorldToCell(worldPoint);
                //if (tilemaps[i].GetTile(position) != null)
                //{
                //    currentPos = position;
                //    currentTilemap = tilemaps[i];
                //    break;
                //}
            }


            if (currentTilemap != null)
            {
                TileBase tile = currentTilemap.GetTile(currentPos);
                Debug.Log(currentPos);
                //currentTilemap.SetTileFlags(currentPos, TileFlags.None);
                currentTilemap.SetTile(currentPos, null);
            }

        }

    }

    private void Shovel(Vector3Int currentPos)
    {
        Debug.Log("x = " + dirtGrid.GetLength(0));
        Debug.Log("y = " + dirtGrid.GetLength(1));
        currentPos += new Vector3Int(dirtGrid.GetLength(0) / 2, dirtGrid.GetLength(1) / 2, 0);
        for (int i = -displayScript.ShovelSize + 1; i < displayScript.ShovelSize; i++)
        {
            for (int j = -displayScript.ShovelSize + 1; j < displayScript.ShovelSize; j++)
            {
                Debug.Log("x = " + (currentPos.x + i) + " y = " + (currentPos.y + j));
                if ((currentPos.x + i) >= 0 && (currentPos.x + i) < dirtGrid.GetLength(0) &&
                    (currentPos.y + j) >= 0 && (currentPos.y + j) < dirtGrid.GetLength(1))
                {
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
