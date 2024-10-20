using TMPro;
using UnityEngine;

public class GraveCountChecker : MonoBehaviour
{

    public int GraveCounter {  get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseGraveCount()
    {
        GraveCounter++;
        GetComponent<TextMeshProUGUI>().text = $"{GraveCounter} / 5 Graves Robbed";
    }
}
