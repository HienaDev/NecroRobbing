using UnityEngine;
using UnityEngine.UI;

public class SummonCheck : MonoBehaviour
{
    [SerializeField] private Button summonButton;
    private Drop[] summonSpaces;
    private int numReady;
    void Start()
    {
        summonSpaces = FindObjectsByType<Drop>(0);
    }

    void Update()
    {
        foreach (Drop space in summonSpaces)
        {
            if (space.IsPlaced)
                numReady++;
        }
        Debug.Log(numReady);
        if (numReady == 6)
            summonButton.interactable = true;
        else
            numReady = 0;
    }
    public void Summon()
    {
        Debug.Log("SUMMON CODE HERE");
        summonButton.interactable = false;
    }
}
