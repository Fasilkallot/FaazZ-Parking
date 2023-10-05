
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public bool onPause;
    public PauseMenuScript pauseMenu;
    private void Start()
    {
        GameManager.Instance.sceneController = this;
    }
    public void Play(int level)
    {
        GameManager.Instance.currentLevel = level;
        DontDestroyOnLoad(GameManager.Instance.current_Player);
        GameManager.Instance.currentState = GameState.PalayingState;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(level);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Next()
    {
        GameManager.Instance.currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.Instance.currentState = GameState.PalayingState;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GameManager.Instance.currentLevel);
    }
    public void Restart()
    {
        GameManager.Instance.currentState = GameState.PalayingState;
        GameManager.Instance.carController.CarToIdle();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Destroy(GameManager.Instance.current_Player);
        SceneManager.LoadScene(0);
        GameManager.Instance.currentState = GameState.PauseState;

    }
    public void QuitButton()
    {
        Application.Quit();
    }



    



}
