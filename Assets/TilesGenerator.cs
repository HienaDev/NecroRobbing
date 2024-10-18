using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilesGenerator : MonoBehaviour
{
    [System.Serializable]
    public class Bone
    {
        public Vector3[] boneConfig;
        public Tile[] tilesInOrder;
    }

    [SerializeField] private Vector2Int gridSize;

    [Header("Grave"), SerializeField] private Tilemap gridDirt;
    [SerializeField] private Tile hardTile3;
    [SerializeField] private Tile softTile2;
    [SerializeField] private Tile dirtTile1;
    private int[,] gridDirtNumbers;

    [Header("Bones"), SerializeField] private Tilemap gridBones;
    [SerializeField] private int numberOfBonesToGenerate = 3;
    [SerializeField] private Bone[] smallBones;
    [SerializeField] private Bone[] mediumBones;
    [SerializeField] private Bone[] bigBones;
    private int[,] gridBonesNumber;
    private List<List<Vector3Int>> generatedBones = new List<List<Vector3Int>>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int x = -gridSize.x / 2 - 2; x < gridSize.x / 2 +2 ; x++)
        {
            for (int y = -gridSize.y / 2 - 2; y < gridSize.y / 2 + 2; y++)
            {
                gridDirt.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
                gridBones.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
            }
        }

        GenerateGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateGame();
        }
    }

    private void GenerateGame()
    {
        GenerateBones();
        //GenerateGrid();
        //GenerateTiles();
    }

    private void GenerateBones()
    {

        gridBonesNumber = new int[gridSize.x, gridSize.y];
        gridBones.ClearAllTiles();
        generatedBones = new List<List<Vector3Int>>();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                gridBonesNumber[x, y] = 0;
            }
        }

        for (int i = 0; i < numberOfBonesToGenerate; i++)
        {
            int numberOfBone = Random.Range(0, smallBones.Length);

            bool generated = false;

            
                bool goodBone = true;
                int x = Random.Range(0, gridSize.x);
                int y = Random.Range(0, gridSize.y);

                List<Vector3Int> changedTiles = new List<Vector3Int>();

                for (int currentVector = 0; currentVector < smallBones[numberOfBone].boneConfig.Length; currentVector++)
                {
                    if (smallBones[numberOfBone].boneConfig[currentVector].x == 1)
                    {
                        if((x > 9 || x < 0) || (y + currentVector > 9 || y + currentVector < 0))
                        {
                            Debug.Log("bad bone because out of grid");
                            goodBone = false;
     
                            break;
                        }
                        if (gridBonesNumber[x, y + currentVector] == 0)
                        {
                            gridBonesNumber[x, y + currentVector] = 1;
                            changedTiles.Add(new Vector3Int(x, y + currentVector));
                        }
                        else
                        {
                            Debug.Log("bad bone because bone already there");
                            goodBone = false;

                            break;
                        }
                    }

                    if (smallBones[numberOfBone].boneConfig[currentVector].y == 1)
                    {
                        if ((x + 1 > 9 || x + 1 < 0) || (y + currentVector > 9 || y + currentVector < 0))
                        {
                            Debug.Log("bad bone because out of grid");
                            goodBone = false;

                            break;
                        }
                        if (gridBonesNumber[x + 1, y + currentVector] == 0)
                        {
                            gridBonesNumber[x + 1, y + currentVector] = 1;
                            changedTiles.Add(new Vector3Int(x + 1, y + currentVector));
                        }
                        else
                        {
                            Debug.Log("bad bone");
                            goodBone = false;

                            break;
                        }
                    }

                    if (smallBones[numberOfBone].boneConfig[currentVector].z == 1)
                    {
                        if ((x + 2 > 9 || x + 2 < 0) || (y + currentVector > 9 || y + currentVector < 0))
                        {
                            Debug.Log("bad bone because out of grid");
                            goodBone = false;

                            break;
                        }
                        if (gridBonesNumber[x + 2, y + currentVector] == 0)
                        {
                            gridBonesNumber[x + 2, y + currentVector] = 1;
                            changedTiles.Add(new Vector3Int(x + 2, y + currentVector));
                        }
                        else
                        {
                            Debug.Log("bad bone");
                            goodBone = false;

                            break;
                        }
                    }




                }

                generated = goodBone;

                if(generated)
                {
                    generatedBones.Add(changedTiles);
                    Color tileColor = Random.ColorHSV();
                    //Debug.Log(tileColor);
                    
                    for (int boneCoord = 0; boneCoord < changedTiles.Count; boneCoord++)
                    {
                        Vector3Int coordAfterOffset = changedTiles[boneCoord] - new Vector3Int((gridSize.x / 2) - (gridSize.x % 2), (gridSize.x / 2) - (gridSize.x % 2), 0);
                        gridBones.SetTileFlags(coordAfterOffset, TileFlags.None);
                        gridBones.SetTile(coordAfterOffset, smallBones[numberOfBone].tilesInOrder[changedTiles.Count - 1 - boneCoord]);
                        gridBones.SetColor(coordAfterOffset, tileColor);
                        Debug.Log("Bone generated on: " + coordAfterOffset);
                    }

                    
                }
            
        }

        Debug.Log("Bones generated " + generatedBones.Count);

    }

    private void GenerateGrid()
    {
        gridDirtNumbers = new int[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                gridDirtNumbers[x, y] = Random.Range(1, 4);
            }
        }
    }

    private void GenerateTiles()
    {

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                switch (gridDirtNumbers[x, y])
                {
                    case 3:
                        gridDirt.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), hardTile3);
                        break;
                    case 2:
                        gridDirt.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), softTile2);
                        break;
                    case 1:
                        gridDirt.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), dirtTile1);
                        break;
                    case 0:
                        gridDirt.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), null);
                        break;
                    default:
                        gridDirt.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), dirtTile1);
                        gridDirt.SetColor(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                        y - (gridSize.y / 2 - gridSize.y % 2)
                                                        , 0), Color.red);
                        break;
                }
            }
        }



    }
}
