using Unity.Mathematics;
using UnityEngine;

public class ParkingScript : MonoBehaviour
{
    [SerializeField] private Transform parkingPointTransform;
    [SerializeField] private float area = 2f;

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

  

    private void checkParked()
    {
        Vector3 carForward = carPoint.forward;
        Vector3 parkingPointForward = parkingPointTransform.forward;

        float dotProduct = Vector3.Dot(carForward, parkingPointForward);
        float distance = Vector3.Distance(parkingPointTransform.position, carPoint.position);

        if (math.abs(dotProduct)>= 0.8 && distance < area )
        {
            GameManager.Instance.CarInside();
        }
    }
}
