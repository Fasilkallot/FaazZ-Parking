
using TMPro;
using UnityEngine;

public class WinnerMenu : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject winnerMenu;
    public TextMeshProUGUI coinGain;
    public bool isWinner;
    private ParkingScript parkingScript;
    void Start()
    {
        GameManager.Instance.winnerMenu = this;
    }

   public void WinnerPopUp()
    {
        isWinner = true;
        winnerMenu.SetActive(true);
        effect.SetActive(true);
        GameManager.Instance.currentState = GameState.PauseState;

    }
    public void WinnerClose()
    {
        winnerMenu.SetActive(false);
        effect.SetActive(false);

    }
    private void OnEnable()
    {
        ParkingScript.GameWinner += CarInside;
    }
    private void OnDisable()
    {
        ParkingScript.GameWinner -= CarInside;
    }
    public void CarInside(GameObject parkArea)
    {
        GameManager.Instance.parkText.ActiveText();
        if (GameManager.Instance.carController.isParking)
        {
            parkArea.GetComponent<BoxCollider>().enabled = false;   
            GameManager.Instance.LevelCompleted();
            WinnerPopUp();
        }

    }
}
