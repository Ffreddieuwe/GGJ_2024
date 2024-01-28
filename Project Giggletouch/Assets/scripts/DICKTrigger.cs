using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DICKTrigger : MonoBehaviour
{
    public GameObject DICKInjector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DICKInjector.SetActive(false);
        }
    }

}
