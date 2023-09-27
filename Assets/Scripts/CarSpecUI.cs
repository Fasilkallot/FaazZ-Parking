
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarSpecUI : MonoBehaviour
{
    [SerializeField]  Slider torqueSlider;
    [SerializeField]  Slider powerSlider;
    [SerializeField]  Slider maxSpeedSlider;
    [SerializeField]  Button unlockButton;
    [SerializeField]  TextMeshProUGUI coinText;


    TextMeshProUGUI unlockText;
    CarController controller;

    private void Start()
    {
        OnCarChanged(GameManager.Instance.current_Player);
    }
   
    private void OnCarChanged(GameObject car)
    {
        controller = car.GetComponent<CarController>();
        torqueSlider.value = controller.torque;
        powerSlider.value =controller.power;
        maxSpeedSlider.value = controller.maxSpeed;
        if (controller.isUnlocked)
        {
            unlockText.text = "Unlocked";
            unlockButton.interactable = false;
        }
        else
        {
            unlockButton.interactable = true;
            unlockText.text = $"Unlock : {controller.carCost}";
        }
    }

    public void UnlockCar()
    {
        int coins = PlayerPrefs.GetInt("CollectedCoins");
        if (coins < controller.carCost) return;
        
        coins = coins - controller.carCost;
        coinText.text = coins.ToString();
        unlockText.text = "Unlocked";
        unlockButton.interactable = false;
        controller.isUnlocked = true;
        PlayerPrefs.SetInt(controller.carName, 1);
        PlayerPrefs.SetInt("CollectedCoins", coins);
    }

    private void OnEnable()
    {
        unlockText = unlockButton.GetComponentInChildren<TextMeshProUGUI>(); unlockText = unlockButton.GetComponentInChildren<TextMeshProUGUI>();

        MenuManager.CarChange += OnCarChanged;
        unlockButton.onClick.AddListener(UnlockCar);
        coinText.text = PlayerPrefs.GetInt("CollectedCoins").ToString();
    }
    private void OnDisable()
    {
        MenuManager.CarChange -= OnCarChanged;
        unlockButton.onClick.RemoveListener(UnlockCar);
    }
}
