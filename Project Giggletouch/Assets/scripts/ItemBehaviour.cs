using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public InventoryLogic inventoryLogic;
    public AudioClip pickupSound;
    private GameObject[] keyVoices;
    // Start is called before the first frame update

    private void Start()
    {
        keyVoices = GameObject.FindGameObjectsWithTag("key-locked");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 0.5f);
            inventoryLogic.gotKey = true;
            Destroy(gameObject);

            foreach(var item in keyVoices)
            {
                Destroy(item);
            }

        }
    }
}
