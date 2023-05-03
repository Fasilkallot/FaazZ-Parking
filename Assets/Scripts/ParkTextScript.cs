using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkTextScript : MonoBehaviour
{

    private void Start()
    {
        GameManager.Instance.parkText = this;
        gameObject.SetActive(false);

    }
    public void ActiveText()
    {
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        gameObject.SetActive(false); 
    }
}
