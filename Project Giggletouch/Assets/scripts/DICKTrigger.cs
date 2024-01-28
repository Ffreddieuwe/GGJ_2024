using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DICKTrigger : MonoBehaviour
{
    public GameObject DICKInjector;
    public AudioSource LaughAmbience;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DICKInjector.SetActive(false);
            LaughAmbience.enabled = false;


        }
    }

}
