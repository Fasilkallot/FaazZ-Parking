using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject inGameUI
        ;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.sceneController.onPause && (!GameManager.Instance.winnerMenu.isWinner && !GameManager.Instance.gameOverScreen.gameOver))
            {
                ActivePauseMenu();

            }
            else
            {
                DeactivePauseMenu();
            }
        }
    }


    public void ActivePauseMenu()
    {
        pauseMenu.SetActive(true);
        GameManager.Instance.sceneController.onPause = true;
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
    }
    public void DeactivePauseMenu()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.sceneController.onPause = false;
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
    }
 
}
