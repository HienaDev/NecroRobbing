using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void MoveScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
