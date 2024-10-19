using UnityEngine;

public class CheckIfPlayerInside : MonoBehaviour
{

    public bool PlayerInside {  get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponentInParent<TAG_Player>() != null)
        {
            PlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<TAG_Player>() != null)
        {
            PlayerInside = false;
        }
    }
}
