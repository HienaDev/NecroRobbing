using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class ClickOnTiles : MonoBehaviour
{

    [SerializeField] private Tilemap[] tilemaps;
    private Tilemap currentTilemap = null;
    private Vector3Int currentPos = Vector3Int.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);


            for (int i = 0; i < tilemaps.Length; i++)
            {
                Vector3Int position = tilemaps[i].WorldToCell(worldPoint);
                if (tilemaps[i].GetTile(position) != null)
                {
                    currentPos = position;
                    currentTilemap = tilemaps[i];
                    break;
                }
            }

            
            if(currentTilemap != null)
            {
                TileBase tile = currentTilemap.GetTile(currentPos);
                Debug.Log(currentPos);
                //currentTilemap.SetTileFlags(currentPos, TileFlags.None);
                currentTilemap.SetTile(currentPos, null);
            }
            
        }
        
    }
}
