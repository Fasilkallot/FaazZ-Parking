using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ParkingScript : MonoBehaviour
{
    [SerializeField] private Transform parkingPointTransform;
    [SerializeField] private float area = 2f;

    private Material parkingAreaMaterial;
    private Transform carPoint;
    
  
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.parkText.Deactivate();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            carPoint = other.transform;
            checkParked();
        }
    }
    private async void checkParked()
    {
        Vector3 carForward = carPoint.forward;
        Vector3 parkingPointForward = parkingPointTransform.forward;

        float dotProduct = Vector3.Dot(carForward, parkingPointForward);
        float distance = Vector3.Distance(parkingPointTransform.position, carPoint.position);

        if (math.abs(dotProduct) >= 0.8 && distance < area)
        {
            parkingAreaMaterial.color = Color.green;
            GameManager.Instance.parkText.ActiveText();

            if (GameManager.Instance.current_Player.GetComponent<CarController>().isParking)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                GameManager.Instance.LevelCompleted();
                GameManager.Instance.winnerMenu.WinnerPopUp();
            }
        }
        else
        {
            parkingAreaMaterial.color = Color.yellow;
        }
    }
    private void Awake()
    {
        parkingAreaMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }
}
