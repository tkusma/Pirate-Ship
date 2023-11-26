using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
