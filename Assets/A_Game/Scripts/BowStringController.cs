using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField]
    private BowString bowStringRenderer;

    private XRGrabInteractable interactable;

    [SerializeField]
    private Transform midPointGrabObject, midPointVisualObject, midPointParent;

    private Transform interactor;

    private float bowStringStretchLimit = 0.05f;

    private float strength, previousStrength;


    [SerializeField]
    private float stringSoundThreshold = 0.001f;

    [SerializeField]
    private AudioSource stringPullAudioSource;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    private void Awake()    
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(strength);
        strength = 0;
        previousStrength = 0;
        stringPullAudioSource.pitch = -1;
        stringPullAudioSource.Stop();

        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
        OnBowPulled?.Invoke();
    }

    private void Update()
    {
        if (interactor != null)
        {
            //convert bow string mid point position to the local space of the MidPoint
            Vector3 midPointLocalSpace =
                midPointParent.InverseTransformPoint(midPointGrabObject.position); // localPosition

            //get the offset
            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);

            previousStrength = strength;

            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackTolimit(midPointLocalZAbs, midPointLocalSpace);

            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);

            bowStringRenderer.CreateString(midPointVisualObject.position);
        }
    }

    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z > 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            if (stringPullAudioSource.isPlaying == false && strength <= 0.01f)
            {
                stringPullAudioSource.Play();
            }
            strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);

            PlayStringPullInSound();
        }
    }

    private void PlayStringPullInSound()
    {
        if (Mathf.Abs(strength - previousStrength) > stringSoundThreshold)
        {
            if (strength < previousStrength)
            {
                stringPullAudioSource.pitch = -1;
            }
            else
            {
                stringPullAudioSource.pitch = 1;
            }
            stringPullAudioSource.UnPause();
        }
        else
        {
            stringPullAudioSource.Pause();
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackTolimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z > 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            stringPullAudioSource.Pause();
            strength = 1;
            midPointVisualObject.localPosition = new Vector3(0, 0, bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z <= 0)
        {
            stringPullAudioSource.pitch = 1;
            stringPullAudioSource.Stop();
            strength = 0;
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }

}