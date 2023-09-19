using System;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public static Action gotHit;


    private void OnCollisionEnter(Collision collision)
    {
        gotHit?.Invoke();
    }
    
}
