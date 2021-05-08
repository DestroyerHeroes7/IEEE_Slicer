using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sharpRigidbody;
    public bool shouldMove;
    public float moveSpeed;

    public float angularForce;
    public float jumpForce;
    private void Start()
    {
        rb.maxAngularVelocity = 15;
    }
    void Update()
    {
        if (shouldMove)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime,Space.World);
    }
    public void OnMouseButtonUp()
    {
        ThrowKnife();
    }
    public void ThrowKnife()
    {
        rb.AddTorque(Vector3.forward * angularForce,ForceMode.Impulse);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
