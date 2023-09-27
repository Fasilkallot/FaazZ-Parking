
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
        if (!GameManager.Instance.current_Player.GetComponent<CarController>().isUnlocked) return;
        GameManager.Instance.currentLevel = level;
        DontDestroyOnLoad(GameManager.Instance.current_Player);
        SceneManager.LoadScene(level);
        GameManager.Instance.currentState = GameState.PalayingState;
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Next()
    {
        GameManager.Instance.currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(GameManager.Instance.currentLevel);
        GameManager.Instance.currentState = GameState.PalayingState;
        Time.timeScale = 1.0f;

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.currentState = GameState.PalayingState;
        GameManager.Instance.carController.CarToIdle();
        Time.timeScale = 1.0f;
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
    public void Park()
    {
        GameManager.Instance.carController.isParking = !(GameManager.Instance.carController.isParking);
    }
    public void ApplyBreak()
    {
        GameManager.Instance.carController.isBraking = true;
    }
    public void RemoveBreak()
    {
        GameManager.Instance.carController.isBraking = false;
    }
    



}
