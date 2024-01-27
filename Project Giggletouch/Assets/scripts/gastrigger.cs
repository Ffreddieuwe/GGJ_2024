using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class gastrigger : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    private ChromaticAberration chromaticAberration;
    private Grain grain;
    public ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    public float decayTime = 5.0f;
    private bool inGas = false;
    public float increasedValue = 0.0f;

    private void Start()
    {
        chromaticAberration = postProcessProfile.GetSetting<ChromaticAberration>();
        grain = postProcessProfile.GetSetting<Grain>();
        particleSystem = GetComponent<ParticleSystem>();
        emissionModule = particleSystem.emission;

        chromaticAberration.intensity.Override(0);
        grain.intensity.Override(0);
        grain.size.Override(0);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            decayTime = 5.0f;
            inGas = true;

            increasedValue += 0.05f * emissionModule.rateOverTime.constant * Time.deltaTime;
            Debug.Log(emissionModule.rateOverDistance.constant);

            chromaticAberration.intensity.Override(increasedValue);
            grain.intensity.Override(increasedValue);
            grain.size.Override(increasedValue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inGas = false;
        increasedValue = 0.0f;
    }

    private void FixedUpdate()
    {
        decayTime -= 1 * Time.deltaTime;

        if (!inGas && decayTime <= 0.0f)
        {
            chromaticAberration.intensity.Override(chromaticAberration.intensity.value - 0.4f * Time.deltaTime);
            grain.intensity.Override(grain.intensity.value - 0.3f * Time.deltaTime);
            grain.size.Override(grain.size.value - 0.8f * Time.deltaTime);
        }

    }

}
