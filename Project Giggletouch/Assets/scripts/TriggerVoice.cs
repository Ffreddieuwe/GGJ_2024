using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerVoice : MonoBehaviour
{
    private GameObject player;
    private AudioSource playerAudio;
    public AudioClip voiceClip;
    public bool played;
    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAudio = player.GetComponentInChildren<AudioSource>();

    }

    private void Update()
    {
        if (!playerAudio.isPlaying)
        {
            player.GetComponent<Player_Movement>().frozen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !played)
        {
            if (freeze)
            {
                player.GetComponent<Player_Movement>().frozen = true;
            }

            played = true;
            playerAudio.Stop();
            playerAudio.PlayOneShot(voiceClip);
        }
    }
}
