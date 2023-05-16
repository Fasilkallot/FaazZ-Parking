using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform carPosition;

    Transform player;

    private void OnEnable()
    {
       
        player = GameManager.Instance.player.transform;
        player.SetPositionAndRotation(carPosition.position, carPosition.rotation);
    }
}
