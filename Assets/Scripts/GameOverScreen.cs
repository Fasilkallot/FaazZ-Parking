
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.gameOverScreen = this;
        gameObject.SetActive(false);
    }
    public void GameOverScreenPopUp()
    {
        gameObject.SetActive(true);
        GameManager.Instance.sceneController.inGameUI.SetActive(false);
        if (!GameManager.Instance.sceneController.onPause)
        {
            GameManager.Instance.sceneController.onPause = true;
            Time.timeScale = 0f;
        }
    }
    public void GameOverScreenExit()
    {
        gameObject.SetActive(false);    
    }
}
