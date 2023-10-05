
using UnityEngine;

public class CarSound : MonoBehaviour
{
    private Rigidbody carRigidbody;
    private AudioSource carAudio;

    public float minSpeed = 0.0f;
    public float maxSpeed = 100.0f;

    public float minPitch = 0.5f;
    public float maxPitch = 1.5f;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();

        // Make sure the audio loops.
        carAudio.loop = true;
    }

    private void Update()
    {
        if (GameManager.Instance.currentState == GameState.PalayingState)
        {
            float currentSpeed = carRigidbody.velocity.magnitude;

            // Calculate the pitch based on the current speed.
            float speedPercentage = Mathf.InverseLerp(minSpeed, maxSpeed, currentSpeed);
            float pitch = Mathf.Lerp(minPitch, maxPitch, speedPercentage);

            carAudio.pitch = pitch;

            if (!carAudio.isPlaying)
            {
                carAudio.Play();
            }
        }
        else
        {
            carAudio.Stop();
        }
    }
}
