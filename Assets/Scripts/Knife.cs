using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb.AddTorque(Vector3.forward * 10);
    }
    void Update()
    {
        
    }
}
