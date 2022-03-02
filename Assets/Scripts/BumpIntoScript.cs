using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpIntoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("asdfasdf");
        if (other.collider.CompareTag("Obstacle"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            BezierFollow bf = GetComponent<BezierFollow>();
            bf.enabled = false;
            bf.shouldStop = true;
        }
    }
}
