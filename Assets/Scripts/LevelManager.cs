using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform carPosition;

    Transform player;

    private void OnEnable()
    {
       
        player = GameManager.Instance.current_Player.transform;
        player.SetPositionAndRotation(carPosition.position, carPosition.rotation);
    }
}
