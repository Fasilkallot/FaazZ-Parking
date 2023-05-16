using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Transform carPosition;

    private void OnEnable()
    {
        GameManager.Instance?.player?.transform.SetPositionAndRotation(carPosition.position, carPosition.rotation);

    }
}
