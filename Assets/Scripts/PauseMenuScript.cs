using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu;

    bool onPause = false;

    private void Update()
    {
        if (GameManager.Instance.currentState == GameState.PalayingState)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!onPause)
                {
                    ActivePauseMenu();
                }
                else
                {
                    DeactivePauseMenu();
                }
            }
        }
    }


    public void ActivePauseMenu()
    {
        pauseMenu.SetActive(true);
        onPause = true;
        Time.timeScale = 0f;
    }
    public void DeactivePauseMenu()
    {
        pauseMenu.SetActive(false);
        onPause = false;
        Time.timeScale = 1f;
    }
 
}
