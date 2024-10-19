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
    private List<Bone> generatedBonesSprites = new List<Bone>();


    [Header("GRID"), SerializeField] private ClickOnTiles clickOnTileScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int x = -gridSize.x / 2 - 2; x < gridSize.x / 2 + 2; x++)
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
        GenerateGrid();
        SendGridData();
        GenerateTiles();
    }

    private void SendGridData()
    {
        clickOnTileScript.ReceiveGridData(gridDirtNumbers, gridBonesNumber);
    }

    public void UpdateTiles(int[,] dirt, int[,] bones)
    {
        gridDirtNumbers = dirt;
        gridBonesNumber = bones;
        GenerateTiles();
    }

    private void GenerateBones()
    {

        gridBonesNumber = new int[gridSize.x, gridSize.y];
        gridBones.ClearAllTiles();
        generatedBones = new List<List<Vector3Int>>();
        generatedBonesSprites = new List<Bone>();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                gridBonesNumber[x, y] = 0;
            }
        }

        for (int i = 0; i < numberOfBonesToGenerate; i++)
        {
            int typeOfBone = Random.Range(0, 3);

            Bone[] listOfBones = null;

            switch (typeOfBone)
            {
                case 0:
                    listOfBones = smallBones;
                    break;
                case 1:
                    listOfBones = mediumBones;
                    break;
                case 2:
                    listOfBones = bigBones;
                    break;
                default:
                    break;
            }

            int numberOfBone = Random.Range(0, listOfBones.Length);

            bool generated = false;


            bool goodBone = true;
            int x = Random.Range(0, gridSize.x);
            int y = Random.Range(0, gridSize.y);

            List<Vector3Int> changedTiles = new List<Vector3Int>();

            for (int currentVector = 0; currentVector < listOfBones[numberOfBone].boneConfig.Length; currentVector++)
            {
                if (listOfBones[numberOfBone].boneConfig[currentVector].x == 1)
                {
                    if ((x > gridSize.x - 1 || x < 0) || (y + currentVector > gridSize.y - 1 || y + currentVector < 0))
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

                if (listOfBones[numberOfBone].boneConfig[currentVector].y == 1)
                {
                    if ((x + 1 > gridSize.x - 1 || x + 1 < 0) || (y + currentVector > gridSize.y - 1 || y + currentVector < 0))
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

                if (listOfBones[numberOfBone].boneConfig[currentVector].z == 1)
                {
                    if ((x + 2 > gridSize.x - 1 || x + 2 < 0) || (y + currentVector > gridSize.y - 1 || y + currentVector < 0))
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

            if (generated)
            {
                generatedBones.Add(changedTiles);
                generatedBonesSprites.Add(listOfBones[numberOfBone]);

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

        for (int currentBone = 0; currentBone < generatedBones.Count; currentBone++)
        {
            for (int boneCoord = 0; boneCoord < generatedBones[currentBone].Count; boneCoord++)
            {
                Vector3Int coordAfterOffset = generatedBones[currentBone][boneCoord] - new Vector3Int((gridSize.x / 2), (gridSize.y / 2), 0);
                gridBones.SetTileFlags(coordAfterOffset, TileFlags.None);
                gridBones.SetTile(coordAfterOffset, generatedBonesSprites[currentBone].tilesInOrder[generatedBones[currentBone].Count - 1 - boneCoord]);

                Debug.Log("Bone generated on: " + coordAfterOffset);
            }
        }



    }
}
