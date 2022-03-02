using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public CapsuleCollider mainCollider;
    public GameObject characterRig;
    
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Projectile"))
        {
            RagdollModeOn();
        }
    }


    private Collider[] ragdollColiders;
    private Rigidbody[] limbsRigidbodies;
    
    void GetRagdollBits()
    {
        ragdollColiders = characterRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = characterRig.GetComponentsInChildren<Rigidbody>();
        
    }

    void RagdollModeOn()
    {
        foreach (Collider col in ragdollColiders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rig in limbsRigidbodies)
        {
            rig.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    {
        foreach (Collider col in ragdollColiders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rig in limbsRigidbodies)
        {
            rig.isKinematic = true;
        }

        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        
    }
    
}
