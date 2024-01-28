using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video_Script : MonoBehaviour
{
    private VideoPlayer video_player;
    private float timer;

    private void Awake()
    {
        video_player = this.GetComponent<VideoPlayer>();
        video_player.Play();
        timer = 5.0f;
    }

    private void Update()
    {
        if (video_player.isPlaying)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            if (!video_player.isPlaying)
            {
                timer = 5;
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            }
        }
    }
}
