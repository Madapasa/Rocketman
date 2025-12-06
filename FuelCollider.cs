using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class FuelCollider : MonoBehaviour
{

    [SerializeField] GameObject rocket;
    [SerializeField] AudioClip collect;
    AudioSource playsound;

    void Start()
    {
        playsound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject == rocket){

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            playsound.PlayOneShot(collect); 
        } 
    }

    
}
