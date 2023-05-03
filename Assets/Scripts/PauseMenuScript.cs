using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
   

    public void ActivePauseMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void DeactivePauseMenu()
    {
        gameObject.SetActive(false);    
        Time.timeScale = 1f;
    }
 
}
