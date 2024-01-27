using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GasReaction : MonoBehaviour
{

    public PostProcessProfile postProcessProfile;
    public AudioClip audioClip;
    public AudioSource audioSource; 
    public float volume = 0.5f;
    private bool alerted = false; 
    private ChromaticAberration chromaticAberration;


    // Start is called before the first frame update
    void Start()
    {
        chromaticAberration = postProcessProfile.GetSetting<ChromaticAberration>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(chromaticAberration.intensity.value);
        if(chromaticAberration.intensity.value >= 0.7f && !alerted)
        {
            alerted = true; 
            audioSource.PlayOneShot(audioClip,volume);
            Debug.Log("played Audio");
        }
        else if(chromaticAberration.intensity.value <= 0.5f)
        {
            alerted = false; 
        }
    }
}
