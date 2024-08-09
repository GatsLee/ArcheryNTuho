using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    public GameObject rayController;
    public GameObject directController;

    public Transform startTf;
    private RaycastHit hitInfo;
    private Color color;

    void Update()
    {
        if (Physics.Raycast(startTf.position, startTf.forward, out hitInfo, 100.0f))
        {
            Debug.Log("hitInfo.collider.tag: " + hitInfo.collider.tag);
            if (hitInfo.collider.tag == "UI")
            {
                rayController.SetActive(true);
                directController.SetActive(false);
            }
        }
        else
        {
            rayController.SetActive(false);
            directController.SetActive(true);
        }
    }
}
