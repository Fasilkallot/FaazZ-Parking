using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Transform carPosition;
    [SerializeField] GameObject[] cars;
    int carIndex = 0;

    private void OnEnable()
    {
        GameManager.Instance?.player?.transform.SetPositionAndRotation(carPosition.position, carPosition.rotation);
        
    }
    private void Start()
    {
        cars[carIndex].gameObject.SetActive(true);
    }

    public void PrevButton()
    {
        if (carIndex == 0) return;
        cars[carIndex].gameObject.SetActive(false);
        carIndex--;
        Debug.Log(carIndex);
        cars[carIndex].gameObject.SetActive(true);
    }
    public void NextButton()
    {
        if(carIndex == cars.Length - 1) return;
        cars[carIndex].gameObject.SetActive(false);
        carIndex++;
        Debug.Log(carIndex);
        cars[carIndex].gameObject.SetActive(true);
    }
}
