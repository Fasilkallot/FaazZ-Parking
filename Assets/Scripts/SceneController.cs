
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool onPause;
    public PauseMenuScript pauseMenu;

    private void Start()
    {
        GameManager.Instance.sceneController = this;
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (onPause)
        {
            Time.timeScale = 1.0f;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (onPause)
        {
            Time.timeScale = 1.0f;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!onPause)
            {
                pauseMenu.ActivePauseMenu();
                onPause = true;
            }
            else
            {
                pauseMenu.DeactivePauseMenu();
                onPause = false;
            }
        }
    }
}
