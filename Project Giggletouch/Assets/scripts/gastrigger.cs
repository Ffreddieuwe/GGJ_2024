using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class gastrigger : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    public GasReaction gasReaction;
    public GameObject mainCamera;


    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        gasReaction = mainCamera.GetComponent<GasReaction>();

         
        particleSystem = GetComponent<ParticleSystem>();    
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gasReaction.Decay(emissionModule.rateOverTime.constant);
        }
    }

    private void OnTriggerExit(Collider other)
    {
   
        gasReaction.increasedValue = 0.0f;
        gasReaction.inGas = false; 
    }

    private void FixedUpdate()
    {


    }

}
