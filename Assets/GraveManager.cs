using UnityEngine;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private GameObject graveDigging;
    private CheckIfPlayerInside checkPlayerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPlayerScript = GetComponentInChildren<CheckIfPlayerInside>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayerScript.PlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            graveDigging.SetActive(true);
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
