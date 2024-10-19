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

    private SpriteRenderer[] renderers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPlayerScript = GetComponentInChildren<CheckIfPlayerInside>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayerScript.PlayerInside)
        {
            foreach (SpriteRenderer sr in renderers)
            {
                sr.color = Color.red;
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                graveSelection.SetActive(false);
                graveDigging.SetActive(true);
                graveCounter.IncreaseGraveCount();
                gameObject.GetComponent<GraveManager>().enabled = false;
            }
                
        }
        else
        {
            foreach (SpriteRenderer sr in renderers)
            {
                sr.color = Color.white;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
