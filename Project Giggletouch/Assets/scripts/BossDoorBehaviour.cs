using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorBehaviour : MonoBehaviour
{
    private bool inZone;
    public bool disabled;
    private InventoryLogic playerInventory;
    public AudioClip doorSlam; 
 
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryLogic>();


    }

    private void Update()
    {
        if (inZone)
        {
            if (Input.GetKeyDown(KeyCode.E) && !disabled && playerInventory.gotKey)
            {
                //audioSource.PlayOneShot();
                // audioSource.PlayOneShot();
                gameObject.transform.Rotate(0, 0, 90);
                disabled = true;

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
        gameObject.transform.Rotate(0, 0, 0);
        AudioSource.PlayClipAtPoint(doorSlam, transform.position);
    }

}
