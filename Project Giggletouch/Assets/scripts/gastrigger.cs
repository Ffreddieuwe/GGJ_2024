using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gastrigger : MonoBehaviour
{
    public GameObject hazyVision;

    private void Start()
    {
        hazyVision = 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
