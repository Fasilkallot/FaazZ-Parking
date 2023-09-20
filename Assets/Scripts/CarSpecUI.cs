
using UnityEngine;
using UnityEngine.UI;

public class CarSpecUI : MonoBehaviour
{
    [SerializeField] private Slider torqueSlider;
    [SerializeField] private Slider powerSlider;
    [SerializeField] private Slider maxSpeedSlider;


    private void OnCarChanged(GameObject car)
    {
        CarController controller = car.GetComponent<CarController>();
        torqueSlider.value = controller.torque;
        powerSlider.value =controller.power;
        maxSpeedSlider.value = controller.maxSpeed;
    }

    private void OnEnable()
    {
        MenuManager.CarChange += OnCarChanged;
    }
    private void OnDisable()
    {
        MenuManager.CarChange -= OnCarChanged;
    }
}
