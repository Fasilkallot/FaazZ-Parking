
using System.Collections;
using TMPro;
using UnityEngine;

public class ParkTextScript : MonoBehaviour
{
    private TextMeshProUGUI parkText;
    private IEnumerator Start()
    {
        GameManager.Instance.parkText = this;
        parkText = GetComponent<TextMeshProUGUI>();

        yield return new WaitForSeconds(6);

        parkText.text = "Press 'P' to Park";
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
