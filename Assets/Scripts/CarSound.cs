using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody carRb;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

     void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();
    }
     void EngineSound()
    {
        currentSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 20f;

        if(currentSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }
        if(currentSpeed >minSpeed && currentSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }
        if(currentSpeed > maxSpeed)
        {
            carAudio.pitch = maxPitch;
        }
    }
    private void Update()
    {
        EngineSound();
    }
}
