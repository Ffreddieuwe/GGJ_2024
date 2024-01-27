using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class gastrigger : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    private ChromaticAberration chromaticAberration;
    private Grain grain; 

    private void Start()
    {
        chromaticAberration = postProcessProfile.GetSetting<ChromaticAberration>();
        grain = postProcessProfile.GetSetting<Grain>();

        chromaticAberration.intensity.Override(0);
        grain.intensity.Override(0);
        grain.size.Override(0);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chromaticAberration.intensity.Override(chromaticAberration.intensity.value + 0.2f * Time.deltaTime);
            grain.intensity.Override(grain.intensity.value + 0.1f * Time.deltaTime);
            grain.size.Override(grain.size.value + 0.5f * Time.deltaTime);
        }
    }
}
