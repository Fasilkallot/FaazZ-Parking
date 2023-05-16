using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerMenu : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    void Start()
    {
        GameManager.Instance.winnerMenu = this;
        gameObject.SetActive(false);
    }

   public void WinnerPopUp()
    {
        gameObject.SetActive(true);
        effect.SetActive(true);
        GameManager.Instance.sceneController.inGameUI.SetActive(false);

    }
    public void WinnerClose()
    {
        gameObject.SetActive(false);
        effect.SetActive(false);
        GameManager.Instance.sceneController.inGameUI.SetActive(true);

    }
}
