using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.ParticleSystem;

public class GasReaction : MonoBehaviour
{


    public PostProcessProfile postProcessProfile;
    private ChromaticAberration chromaticAberration;
    private Grain grain;

    public AudioClip audioClip;
    public AudioSource audioSource;
    public float volume = 0.5f;
    private bool alerted = false;

    public float decayRate = 0.05f;
    public float decayTime = 5.0f;
    public bool inGas = false;
    public float increasedValue = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        chromaticAberration = postProcessProfile.GetSetting<ChromaticAberration>();
        grain = postProcessProfile.GetSetting<Grain>();


        chromaticAberration.intensity.Override(0);
        grain.intensity.Override(0);
        grain.size.Override(0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Recover();
        DecayAlert();
    }

    public void Decay(float emissionRateConstant)
    {
        decayTime = 5.0f;
        inGas = true;

        increasedValue += decayRate * emissionRateConstant * Time.deltaTime;

        chromaticAberration.intensity.Override(increasedValue);
        grain.intensity.Override(increasedValue);
        grain.size.Override(increasedValue);
    }

    public void Recover()
    {
        decayTime -= 1 * Time.deltaTime;

        if (!inGas && decayTime <= 0.0f)
        {
            chromaticAberration.intensity.Override(chromaticAberration.intensity.value - 0.4f * Time.deltaTime);
            grain.intensity.Override(grain.intensity.value - 0.3f * Time.deltaTime);
            grain.size.Override(grain.size.value - 0.8f * Time.deltaTime);
        }
    }
    
    public void DecayAlert()
    {
        if (chromaticAberration.intensity.value >= 0.7f && !alerted)
        {
            alerted = true;
            audioSource.PlayOneShot(audioClip, volume);
            Debug.Log("played Audio");
        }
        else if (chromaticAberration.intensity.value <= 0.5f)
        {
            alerted = false;
        }
    }
}
