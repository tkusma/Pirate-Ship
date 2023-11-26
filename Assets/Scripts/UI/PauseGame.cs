using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !GameManager.manager.GameOver)
        {
            if (pauseMenu.activeSelf)
                Unpause();
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
