using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public List<GameObject> parts;
    public BoxCollider detectionCollider;

    public List<MeshRenderer> meshRenderer;
    private void Start()
    {
        Color color = RandomColor();
        meshRenderer.ForEach(x => x.material.color = color);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Sharp"))
        {
            detectionCollider.enabled = false;
            parts.ForEach(x =>
            {
                x.GetComponent<Collider>().enabled = true;
                Rigidbody r = x.GetComponent<Rigidbody>();
                r.isKinematic = false;
                r.useGravity = true;
                r.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
                r.AddRelativeTorque(Vector3.right, ForceMode.Impulse);
            });
        }
    }
    public Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
