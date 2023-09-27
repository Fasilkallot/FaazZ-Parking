using System;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static event Action<GameObject> CarChange;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject modeMoenu;
    [SerializeField] Transform carPosition;
    [SerializeField] GameObject[] cars;
    int carIndex = 0;

    private void OnEnable()
    {
        GameManager.Instance.current_Player = cars[carIndex];
        GameManager.Instance?.current_Player?.transform.SetPositionAndRotation(carPosition.position, carPosition.rotation);
    }
    private void Start()
    {
        cars[carIndex].gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.Instance.current_Player = cars[carIndex];
    }

    public void PrevButton()
    {
        cars[carIndex].SetActive(false);
        carIndex = (carIndex + 1) % cars.Length;
        cars[carIndex].SetActive(true);
        CarChange?.Invoke(cars[carIndex]);
        GameManager.Instance.current_Player = cars[carIndex];
    }
    public void NextButton()
    {
        cars[carIndex].SetActive(false);
        carIndex--;
        if (carIndex < 0) carIndex += cars.Length;
        cars[carIndex].SetActive(true);
        CarChange?.Invoke(cars[carIndex]);
        GameManager.Instance.current_Player = cars[carIndex];
    }
    public void PlayButton()
    {
        if (cars[carIndex].GetComponent<CarController>().isUnlocked)
        {
            mainMenu.SetActive(false);
            modeMoenu.SetActive(true);
        }
    }
}
