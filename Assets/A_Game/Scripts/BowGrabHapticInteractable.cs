using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowGrabHapticInteractable : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    private XRDirectInteractor interactor;

    private XRBaseController controller;

    [SerializeField]
    public XRGrabInteractable bowGrab;

    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
        interactor.selectEntered.AddListener(TriggerHaptic);
        controller = interactor.xrController;
    }

    private void Update()
    {
        if (interactor.interactablesSelected.Contains(bowGrab))
        {
            TriggerHaptic(controller);
        }
    }

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }
    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
