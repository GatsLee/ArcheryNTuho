using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Debug.Log("Velocity: " + rb.velocity + " Angular Velocity: " + rb.angularVelocity);
  
    }
}
