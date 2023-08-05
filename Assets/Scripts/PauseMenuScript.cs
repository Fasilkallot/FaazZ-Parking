using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
   

    public void ActivePauseMenu()
    {
        gameObject.SetActive(true);
        GameManager.Instance.sceneController.inGameUI.SetActive(false);
        Time.timeScale = 0f;
    }
    public void DeactivePauseMenu()
    {
        gameObject.SetActive(false);
        GameManager.Instance.sceneController.inGameUI.SetActive(true);
        Time.timeScale = 1f;
    }
 
}
