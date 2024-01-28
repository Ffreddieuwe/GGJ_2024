using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;
using UnityEngine.SceneManagement;

public class BossDialogue : MonoBehaviour
{
    private GameObject player;
    private AudioSource playerAudio;
    public AudioClip[] voiceClips;
    public GameObject[] bosses;
    public GameObject bossGas;
    public GameObject invisWall; 


    public bool played;
    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {
        invisWall.SetActive(false);
        freeze = true;
        bossGas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerAudio = player.GetComponentInChildren<AudioSource>();
        bosses = GameObject.FindGameObjectsWithTag("boss");
    }




    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < voiceClips.Length; i++)
        {


            //2.Assign current AudioClip to audiosource
            playerAudio.PlayOneShot(voiceClips[i]);



            //4.Wait for it to finish playing
            while (playerAudio.isPlaying)
            {
                yield return null;
            }

            if (i == 1)
            {
                bossGas.SetActive(true);
            }

            yield return new WaitForSeconds(1);

            bosses[i].GetComponent<VideoPlayer>().enabled = true;
            bosses[i].GetComponentInChildren<Light>().enabled = true;

            yield return new WaitForSeconds((float)bosses[i].GetComponent<VideoPlayer>().length);
            //5. Go back to #2 and play the next audio in the adClips array
        }

        


        played = true;
    }

  


    private void Update()
    {
        if (played)
        {
            SceneManager.LoadScene("Maze");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !played)
        {
            playerAudio.Stop();
            invisWall.SetActive(true);
            if (freeze)
            {
                player.GetComponent<Player_Movement>().frozen = true;

            }

            
            StartCoroutine(playAudioSequentially());
        }

    }
}
