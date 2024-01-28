using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject door;
    private bool inzone;

    private void Start()
    {
        inzone = false;
    }

    private void Update()
    {
        if (inzone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.GetComponent<DoorTrigger>().unlocked = true;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inzone = true;
        }
    }
}
