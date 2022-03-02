using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    //public GameObject playerRef;
    public Transform visibleTarget;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeeTarget;

    private void Start()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Target");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        Collider[] visibleTargets = { };
        

        if (rangeChecks.Length != 0)
        {
            foreach (var target in rangeChecks)
            {
                Transform currentTarget = target.transform;
                Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;
                
                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    //both constraints are met we see this target!
                    float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        canSeeTarget = true;
                        visibleTarget = currentTarget;
                        //Debug.Log("can sse");
                        break;
                    }
                        
                    else
                        canSeeTarget = false;

                }
                else
                    canSeeTarget = false;
                //Debug.Log("cant");
            }
            
        }
        else if (canSeeTarget)
            canSeeTarget = false;
    }
}