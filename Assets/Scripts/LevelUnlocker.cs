
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private Button[] leveButtons;
 
    void Awake()
    {
        if (!PlayerPrefs.HasKey("leveUnlocked")) PlayerPrefs.SetInt("leveUnlocked", 1);

        foreach (Button button in leveButtons)
        {
            button.interactable = false;
        }
        LevelUpdate();
    }
    private void OnEnable()
    {
        LevelUpdate();
    }
  
    public void LevelUpdate()
    {
        int levelsUnlocked = PlayerPrefs.GetInt("leveUnlocked");

        if (levelsUnlocked >= leveButtons.Length) return;

        for (int i = 0; i < levelsUnlocked; i++)
        {
            leveButtons[i].interactable = true;
        }
    }

}
