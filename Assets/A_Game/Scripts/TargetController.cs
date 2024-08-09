using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void GetHit()
    {
        Debug.Log("Target hit!");
    }
}
public interface IHittable
{
    void GetHit();
}