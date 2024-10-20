using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private GameObject graveSelection;
    [SerializeField] private GameObject graveDigging;
    private CheckIfPlayerInside checkPlayerScript;


    [SerializeField] private GameObject grave;
    [SerializeField] private GameObject graveHole;
    private bool graveUsed = false;

    private PlayerMovement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPlayerScript = GetComponentInChildren<CheckIfPlayerInside>();
        player = FindFirstObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPlayerScript.PlayerInside)
        {

            if(Input.GetKeyDown(KeyCode.E) && !graveUsed)
            {

                player.canMove = false;
                StartCoroutine(Dig());

            }
                
        }

    }

    private IEnumerator Dig()
    {
       

        player.animator.SetTrigger("Dig");

        yield return new WaitForSeconds(2f);
        grave.SetActive(false);
        graveHole.SetActive(true);
        graveUsed = true;

        yield return new WaitForSeconds(4f);
        player.canMove = true;
        graveSelection.SetActive(false);
        graveDigging.SetActive(true);
    }

    public void ResetGrave()
    {
        graveUsed = false;
        grave.SetActive(true);
        graveHole.SetActive(false);
    }

}
