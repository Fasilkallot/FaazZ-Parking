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
    public ParkTextScript parkText;
    public CarController carController;
    public WinnerMenu winnerMenu;
    public GameOverScreen gameOverScreen;
    public SceneController sceneController;

    private static bool isGameFinished = false;
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

    public void CarInside()
    {
        parkText.ActiveText();
        if(carController.isParking)
        {
            winnerMenu.WinnerPopUp();
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
}
