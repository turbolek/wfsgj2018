using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCollider : MonoBehaviour {
    public float speed;
   private BoxCollider boxCollider;

    // Use this for initialization
    void Start () {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        otherRB.velocity *= speed;
        Debug.Log("ee" + otherRB);
    }

}
