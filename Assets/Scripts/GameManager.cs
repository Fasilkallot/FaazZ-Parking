using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get { if(instance == null)
            {
                if (isGameFinished) return null;
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<GameManager>();
            } 
        return instance;
        }
        private set
        {
            instance = value;
        }
    }
    private static GameManager instance;

    public Action<GameState> OnStateChangeAction;
    // pause taking input and return do in the room
    public GameState currentState;

    public ParkTextScript parkText;
    public CarController carController;
    public WinnerMenu winnerMenu;
    public GameOverScreen gameOverScreen;
    public SceneController sceneController;
    public PlayerFollow followCamera;
    public TimerScript time;

    private static bool isGameFinished = false;

    public GameObject current_Player;
    public int currentLevel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        currentState = GameState.PauseState;
        currentLevel = PlayerPrefs.GetInt("leveUnlocked");
        if (!PlayerPrefs.HasKey("CollectedCoins")) PlayerPrefs.SetInt("CollectedCoins", 0);
        PlayerPrefs.SetInt("Orange", 1);
    }
    public void LevelCompleted()
    {
        time.timerRunning = false;
        int currentCoins = PlayerPrefs.GetInt("CollectedCoins");
        int coinsGain = currentLevel * 100;
        winnerMenu.coinGain.text = coinsGain.ToString();
        currentCoins = currentCoins + coinsGain;
        PlayerPrefs.SetInt("CollectedCoins", currentCoins);
        if (currentLevel < 10)
        {
            int nextLevel = currentLevel + 1;
            PlayerPrefs.SetInt("leveUnlocked", nextLevel);
        }    
    }

    public void GameOver()
    {
        gameOverScreen.GameOverScreenPopUp();
    }

    private void OnDestroy()
    {
        if(GameManager.Instance == this) isGameFinished = true;
    }
    public void OnStateChange(GameState state)
    {
        currentState = state;
        OnStateChangeAction?.Invoke(currentState);
    }

}

public enum GameState
{    
    PauseState,
    PalayingState
}