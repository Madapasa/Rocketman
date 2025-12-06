using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    [SerializeField]float thruststrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip mainengine;
    
    CollisionHandler collisionscript;
    Rigidbody rb;
    AudioSource _thrustAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _thrustAudio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ThrustMethod();
        RotationMethod();
    }

    public void ThrustMethod()
    {
        if (thrust.IsPressed()) 
        {
            rb.AddRelativeForce(Vector3.up * (thruststrength * Time.fixedDeltaTime)) ;
            if (!_thrustAudio.isPlaying)
            {
                _thrustAudio.PlayOneShot(mainengine);
            }
        }
        else 
        {
            _thrustAudio.Stop();
        }
        
    }

    void RotationMethod ()
    {
       float rotationInput =  rotation.ReadValue<float>();
       if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }
    }

    private void ApplyRotation(float Rotationthisframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * (Rotationthisframe * Time.fixedDeltaTime));
        rb.freezeRotation = false;
    }
}
