using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sharpRigidbody;
    public bool shouldMove;
    public bool canFlip = true;
    public float moveSpeed;

    public float angularForce;
    public float jumpForce;
    public bool canStuck = true;
    private void Start()
    {
        rb.maxAngularVelocity = 15;
        FlipKnife();
    }
    void Update()
    {
        if (shouldMove)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") && canStuck)
        {
            canStuck = false;
            rb.isKinematic = true;
            shouldMove = false;
        }
        if(other.CompareTag("Finish"))
        {
            rb.isKinematic = true;
            shouldMove = false;
            canFlip = false;
            UIManager.Instance.OpenGameEndPanel();
        }
    }
    public IEnumerator OnMouseButtonUp()
    {
        if(canFlip)
        {
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
                shouldMove = true;
                FlipKnife();
                yield return new WaitForSeconds(0.5f);
                canStuck = true;
            }
            else
                FlipKnife();
        }
    }
    public void FlipKnife()
    {
        rb.AddTorque(Vector3.forward * angularForce,ForceMode.Impulse);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
