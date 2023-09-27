
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    public bool gameOver;

    private void Start()
    {
        GameManager.Instance.gameOverScreen = this;
    }
    public void GameOverScreenPopUp()
    {
        if (!(GameManager.Instance.currentState == GameState.PauseState))
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
            GameManager.Instance.currentState = GameState.PauseState;
            Time.timeScale = 0f;
        }
    }
    public void GameOverScreenExit()
    {
        gameOverScreen.SetActive(false);    
    }
    private void OnEnable()
    {
        GameOverScreenExit();
        CarCollision.gotHit += GameOverScreenPopUp;

    }
    private void OnDisable()
    {
        CarCollision.gotHit -= GameOverScreenPopUp;

    }
}
