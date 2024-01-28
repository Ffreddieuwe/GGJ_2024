using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.ParticleSystem;

public class DICKTrigger : MonoBehaviour
{
    public GameObject DICKInjector;
    public AudioSource LaughAmbience;
    public PostProcessProfile postProcess;
    private ChromaticAberration chromaticAberration;
    private Grain grain;

    private void Start()
    {
        chromaticAberration = postProcess.GetSetting<ChromaticAberration>();
        grain = postProcess.GetSetting<Grain>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DICKInjector.SetActive(false);
            LaughAmbience.enabled = false;
            chromaticAberration.intensity.Override(0);
            grain.intensity.Override(0);
        }
    }
}
