using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public CinemachineFreeLook camera;
    private void Start()
    {
        camera = GetComponent<CinemachineFreeLook>();
        camera.Follow = GameManager.Instance.current_Player.transform;
        camera.LookAt = GameManager.Instance.current_Player.transform;
        GameManager.Instance.followCamera = this;
    }
}
