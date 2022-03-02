using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAI : MonoBehaviour
{
    //public GameObject playerRef;
    public GameObject ProjectilePrefab;
    public Transform firePoint;
    public float _initialVelocity = 20.0f;
    
    private FieldOfView fov;
    private Transform visibleTarget;


    void Start()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Target");
        fov = GetComponent<FieldOfView>();
        StartCoroutine(CannonAIRoutine());
    }


    private IEnumerator CannonAIRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1.0f);
        while (true)
        {
            yield return wait;

            visibleTarget = fov.visibleTarget;
            if (fov.canSeeTarget)
                ShootAtTarget(visibleTarget);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootAtTarget(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        //Debug.Log("boom!!!");
        GameObject projectile = Instantiate(ProjectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce( directionToTarget * _initialVelocity, ForceMode.Impulse );
        

    }
}
