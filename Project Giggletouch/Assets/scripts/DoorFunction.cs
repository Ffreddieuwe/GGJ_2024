using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DoorFunction : MonoBehaviour
{
    public AnimationEvent[] events;
    public bool OpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown ("e"))
            {
                if (OpenDoor == false)
                {


                    OpenDoor = true;
                }
                else
                {

                    OpenDoor = false;
                }
            }
            



        }
    }
}
