using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DoorFunction : MonoBehaviour
{
    public Animator door = null;

    public AnimationEvent[] events;
    public bool OpenAnimation = false;
    public bool CloseAnimation = false;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") /*&& Input.GetKeyDown("E")*/)
        {
            if (OpenAnimation == true)
            {
                door.Play("OpenDoor", 0, 0.0f);
            }
            else if (CloseAnimation == true)
            {
                door.Play("DoorClose", 0, 0.0f);
            }
        }
    }
}
