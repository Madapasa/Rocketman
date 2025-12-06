using UnityEngine;
using UnityEngine.Audio;

public class FuelNoise : MonoBehaviour
{
    AudioSource playsound;
    
    void Start()
    {  
        playsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
       GetComponent<MeshRenderer>().enabled = false; 
       GetComponent<SphereCollider>().enabled = false;
       GetComponent<AudioSource>();
       playsound.Play();
    }
}
