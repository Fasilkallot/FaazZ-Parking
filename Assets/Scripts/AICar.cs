
using System;
using UnityEngine;
using UnityEngine.AI;

public class AICar : MonoBehaviour
{
    public Transform[] pathPoints;
    public Transform[] tyres;
    private NavMeshAgent car;

    public float minDistance = 1;
    public float wheelRotationSpeed = 100f;
    private int currentWaypoint = 0;


    private void Start()
    {
        car = GetComponent<NavMeshAgent>();
        SetDestinationToNextWaypoint();
    }

    private void SetDestinationToNextWaypoint()
    {
        if (pathPoints.Length == 0) return;

        car.SetDestination(pathPoints[currentWaypoint].position);

        currentWaypoint = (currentWaypoint + 1) % pathPoints.Length ;
    }
    private void RotateWheels()
    {
        float rotationAmount = car.velocity.magnitude * wheelRotationSpeed * Time.deltaTime;
        
        foreach(Transform tyre in  tyres)
        {
            tyre.Rotate(Vector3.right * rotationAmount);  
        }
    }
    private void Update()
    {
        if(car.remainingDistance<minDistance)
        {
            SetDestinationToNextWaypoint();
        }

        RotateWheels();
    }

    
}
