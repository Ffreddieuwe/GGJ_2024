using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public bool unlocked;

    private void Start()
    {
        unlocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (unlocked)
            {
                SceneManager.LoadScene("Epilogue");
            }
        }
    }
}
