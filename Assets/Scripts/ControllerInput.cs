using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputController : MonoBehaviour
{
    public enum ButtonAction
    {
        OnButtonDown,
        OnButtonUp
    }

    private Dictionary<(OVRInput.RawButton, ButtonAction), System.Action> buttonActions;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize button actions dictionary
        buttonActions = new Dictionary<(OVRInput.RawButton, ButtonAction), System.Action>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check each button and execute its corresponding action based on the specified action type
        foreach (var buttonAction in buttonActions)
        {
            if (buttonAction.Key.Item2 == ButtonAction.OnButtonDown && OVRInput.GetDown(buttonAction.Key.Item1))
            {
                buttonAction.Value.Invoke();
            }
            else if (buttonAction.Key.Item2 == ButtonAction.OnButtonUp && OVRInput.GetUp(buttonAction.Key.Item1))
            {
                buttonAction.Value.Invoke();
            }
        }
    }

    public void AttachFunctionToButton(OVRInput.RawButton button, ButtonAction action, System.Action function)
    {
        var key = (button, action);
        if (buttonActions.ContainsKey(key))
        {
            buttonActions[key] = function;
        }
        else
        {
            buttonActions.Add(key, function);
        }
    }

    public void RemoveFunctionFromButton(OVRInput.RawButton button, ButtonAction action)
    {
        var key = (button, action);
        if (buttonActions.ContainsKey(key))
        {
            buttonActions.Remove(key);
        }
    }
}
