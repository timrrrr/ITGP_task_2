using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpInto : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("dsfasd");
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            
        }
    }
    
    
}
