using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesGenerator : MonoBehaviour
{

    [SerializeField] private Vector2Int gridSize;

    [Header("Dirt"), SerializeField] private Tilemap[] dirtTilemaps;
    [SerializeField] private Tile[] dirtTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GenerateTiles();
        }
    }

    private void GenerateTiles()
    {
        foreach (Tilemap tilemap in dirtTilemaps)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    tilemap.SetTile(new Vector3Int(x - (gridSize.x / 2 - gridSize.x % 2),
                                                   y - (gridSize.y / 2 - gridSize.y % 2), 0),
                                                   dirtTiles[Random.Range(0, dirtTiles.Length)]);
                }
            }
        }
    }
}
