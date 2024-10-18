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
        foreach(Tilemap tilemap in dirtTilemaps) 
        { 
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    tilemap.GetTile(new Vector3Int(x, y, 0));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
