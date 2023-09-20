using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    private void Awake()
    {
        coinText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        coinText.text = PlayerPrefs.GetInt("CollectedCoins").ToString();
    }
}
