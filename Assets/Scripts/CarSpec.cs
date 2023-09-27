
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "ScriptableObjects/CarSpec")]
public class CarSpec : ScriptableObject
{
    public string carName;
    public float power;
    public float torque;
    public float maxSpeed;
    public int carCost;
    public int isUnlocked
    {
        get
        {
            if (!PlayerPrefs.HasKey(carName)) {
                PlayerPrefs.SetInt(carName, 0);
            }
            return PlayerPrefs.GetInt(carName);
        }
        set
        {
            PlayerPrefs.SetInt(carName,value);
        }
    }
}
