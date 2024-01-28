using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GasSwitchBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip disableGasSound;
    public AudioClip valveTurningSound;


    private GameObject[] gasEmitters;
    private bool inZone; 

    public bool disabled;
    // Start is called before the first frame update
    void Start()
    {
        gasEmitters = GameObject.FindGameObjectsWithTag("gas");
    }

    private void Update()
    {
        if (inZone)
        {
            if (Input.GetKeyDown(KeyCode.E) && !disabled )
            {
                audioSource.PlayOneShot(disableGasSound);
                audioSource.PlayOneShot(valveTurningSound);
                disabled = true;
                DisableGas();

            }
        }
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = true;
        }
        
  
    }

    private void OnTriggerExit(Collider other)
    {
        inZone = false;
    }

    void DisableGas()
    {
        foreach(var gas in  gasEmitters)
        {
            gas.SetActive(false);
        }
    }


}
