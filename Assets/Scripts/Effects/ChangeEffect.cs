using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeEffect : MonoBehaviour
{
    public Volume globalVolume;
    private ChromaticAberration chromaticAberration;
    public bool ActiveEffect;
    public float velocity;
    public float transitionTime = 0.5f; // Adjust this value for transition speed

    void Start()
    {
        ActiveEffect = false;
        globalVolume = GetComponent<Volume>();

        if (globalVolume != null && globalVolume.profile != null)
        {
            globalVolume.profile.TryGet(out chromaticAberration);
        }
    }

    void Update()
    {
        if (ActiveEffect)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    void Deactivate()
    {
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.SmoothDamp(chromaticAberration.intensity.value, 0f, ref velocity, transitionTime);
        }
    }

    void Activate()
    {
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.SmoothDamp(chromaticAberration.intensity.value, 1f, ref velocity, transitionTime);
            StartCoroutine(WaitBeforeReset());
        }
    }

    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(4f);
        ActiveEffect = false;
    }
}