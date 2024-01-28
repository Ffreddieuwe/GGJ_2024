using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinalBossScript : MonoBehaviour
{
    public GameObject BossPanel;

    public AudioSource playerSource;
    public AudioClip audioClip;

    private bool talking_started;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        talking_started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (talking_started)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                if (!BossPanel.GetComponent<VideoPlayer>().isPlaying)
                {
                    playerSource.PlayOneShot(audioClip);
                    talking_started = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BossPanel.GetComponent<VideoPlayer>().enabled = true;

        timer = 5.0f;
        talking_started = true;
    }
}
