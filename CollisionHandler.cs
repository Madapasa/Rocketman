using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip success;
    [SerializeField] GameObject fuel;
    [SerializeField] float delay = 0f;
    bool transitioning = true;
    AudioSource playsound;

    void Start()
    {
        
        playsound = GetComponent<AudioSource>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!transitioning) return;
        
        // Using tags to identify the object
        switch (collision.gameObject.tag)
        {
            case ("Friendly"):
                Debug.Log("Welcome");
                break;
            case ("Finish"):
                FinishMethod();
                break;
            case ("Crash"):
                CrashMethod();
                break;

        }        

    }

    private void FinishMethod()
    {
        if (fuel.GetComponent<SphereCollider>().enabled == false && fuel.GetComponent<MeshRenderer>().enabled == false)
        { 
            transitioning = false;
        playsound.Stop();
        playsound.PlayOneShot(success);
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
        }

    }

    private void CrashMethod()
    {
        transitioning = false;
        playsound.Stop();
        playsound.PlayOneShot(explosion);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);     
        
    }

    // if it was WhenTouch("Nextlevel") then the function would be stored to the string "leveltoload"
    // Here are the functions below --
    void ReloadLevel (){
        
       
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
        
        }
        

    void NextLevel()
    {
        
        if(fuel.GetComponent<SphereCollider>().enabled == false && fuel.GetComponent<MeshRenderer>().enabled == false ){ 

        int currentscene = SceneManager.GetActiveScene().buildIndex;
        int nextscene = currentscene + 1;
        if(nextscene == SceneManager.sceneCountInBuildSettings)
    {
        nextscene = 0;
    }

    SceneManager.LoadScene(nextscene);
        }
    }
    // storing these functions into one is a good way of cleaning up your code!
}
