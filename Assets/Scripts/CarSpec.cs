
using UnityEngine;

[CreateAssetMenu(fileName ="Car", menuName ="ScriptableObjects/CarSpec")]
public class CarSpec : ScriptableObject
{
    public string carName;
    public float power;
    public float torque;
    public float Maxspeed;
}
