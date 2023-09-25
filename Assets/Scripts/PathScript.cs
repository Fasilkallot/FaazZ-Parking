
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PathScript : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;

    private LineRenderer lineRenderer;
    private Transform car;
    private NavMeshPath path;

    int currentWaypoint = 0;
    float minDistance = 2f;

    private void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        car = GameManager.Instance.current_Player.transform;
        path = new NavMeshPath();
        lineRenderer.positionCount = 0;
    }
    private void Update()
    {
        if (currentWaypoint < wayPoints.Length)
        {
            NavMesh.CalculatePath(car.position, wayPoints[currentWaypoint].position, NavMesh.AllAreas, path);

            DrawPath();

            if (Vector3.Distance(car.position, wayPoints[currentWaypoint].position) < minDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            lineRenderer.positionCount = 0; 
        }
    }

    private void DrawPath()
    {
        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPositions(path.corners);
    }

}
