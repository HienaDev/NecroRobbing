using UnityEngine;

public class TurnOnOff : MonoBehaviour
{
    private bool isActive = false;

    public void OnOff(GameObject menu)
    {
        isActive = !isActive;
        menu.SetActive(isActive);
    }
}
