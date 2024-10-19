using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Convert mouse position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set object position to follow mouse
        transform.position = worldPosition + new Vector3(0f, 0f, 10f);

    }
}
