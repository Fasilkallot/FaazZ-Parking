
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool onPause;
    public PauseMenuScript pauseMenu;
    public GameObject inGameUI;

    private void Start()
    {
        GameManager.Instance.sceneController = this;
    }
    public void Play()
    {
        DontDestroyOnLoad(GameManager.Instance.current_Player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.currentState = GameState.PalayingState;
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
        GameManager.Instance.currentState = GameState.PalayingState;
        Time.timeScale = 1.0f;
        inGameUI.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.currentState = GameState.PalayingState;
        GameManager.Instance.carController.CarToIdle();
        Time.timeScale = 1.0f;
        inGameUI.SetActive(true);
    }
    public void MainMenu()
    {
        Destroy(GameManager.Instance.player);
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!onPause && (!GameManager.Instance.winnerMenu.isWinner && !GameManager.Instance.gameOverScreen.gameOver) )
            {
                pauseMenu?.ActivePauseMenu();
                onPause = true;
                inGameUI?.SetActive(false);
            }
            else
            {
                pauseMenu?.DeactivePauseMenu();
                onPause = false;
                inGameUI?.SetActive(true);
            }
        }
    }
    
}
