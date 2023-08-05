using UnityEngine;

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

    public GameObject player;
    // pause taking input and return do in the room
    public GameState currentState;

    public ParkTextScript parkText;
    public CarController carController;
    public WinnerMenu winnerMenu;
    public GameOverScreen gameOverScreen;
    public SceneController sceneController;
    public PlayerFollow followCamera;

    private static bool isGameFinished = false;

    public GameObject current_Player;
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
    }

    public void CarInside()
    {
        parkText.ActiveText();
        if(carController.isParking)
        {
            winnerMenu.WinnerPopUp();
            followCamera.camera.enabled = false;
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
    private void UpdateState(GameState newState)
    {
        
    }
}
public enum GameState
{
    PalayingState,
    PauseState

}