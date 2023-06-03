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
        camera.Follow = GameManager.Instance.player.transform;
        camera.LookAt = GameManager.Instance.player.transform;
        GameManager.Instance.followCamera = this;
    }
}
