
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
        Time.timeScale = 1.0f;
        inGameUI.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        inGameUI.SetActive(true);
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
    public void Park()
    {
        GameManager.Instance.carController.isParking = !(GameManager.Instance.carController.isParking);
        Debug.Log("P button adich");
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
            if (!onPause)
            {
                pauseMenu.ActivePauseMenu();
                onPause = true;
                inGameUI.SetActive(true);
            }
            else
            {
                pauseMenu.DeactivePauseMenu();
                onPause = false;
                inGameUI.SetActive(false);
            }
        }
    }
    
}
