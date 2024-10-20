using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private GameObject graveSelection;
    [SerializeField] private GameObject graveDigging;
    private CheckIfPlayerInside checkPlayerScript;

    [SerializeField] private GraveCountChecker graveCounter;


    [SerializeField] private GameObject grave;
    [SerializeField] private GameObject graveHole;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPlayerScript = GetComponentInChildren<CheckIfPlayerInside>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayerScript.PlayerInside && graveCounter.GraveCounter < 5)
        {

            if(Input.GetKeyDown(KeyCode.E))
            {

                graveSelection.SetActive(false);
                graveDigging.SetActive(true);
                graveCounter.IncreaseGraveCount();
                grave.SetActive(false);
                graveHole.SetActive(true);
                gameObject.GetComponent<GraveManager>().enabled = false;
            }
                
        }

    }

}
