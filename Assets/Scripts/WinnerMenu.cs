using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerMenu : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Helloooi");
        GameManager.Instance.winnerMenu = this;
        gameObject.SetActive(false);
    }

   public void WinnerPopUp()
    {
        gameObject.SetActive(true);
    }
    public void WinnerClose()
    {
        gameObject.SetActive(false);
    }
}
