using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float hotDegree;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*hotDegree,ForceMode.Impulse);
    }
}
