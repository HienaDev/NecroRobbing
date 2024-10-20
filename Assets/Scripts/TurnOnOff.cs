using UnityEngine;

public class TurnOnOff : MonoBehaviour
{


    public void OnOff(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
    }
}
