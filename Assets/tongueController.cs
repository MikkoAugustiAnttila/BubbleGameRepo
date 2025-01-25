using System;
using Unity.VisualScripting;
using UnityEngine;

public class tongueController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float returnForce;
    [SerializeField] private float lingerDuration;
    [SerializeField] private Transform mouthPosition;
    private Vector3 targetPosition;
    [SerializeField] private bool isFiring;
    private float curLinger;

    [SerializeField] private GameObject grabbedObject;
    
    
    void Update()
    {
        
        if(Input.GetMouseButton(0) && !isFiring && !grabbedObject)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            targetPosition = mouseWorldPos;
            curLinger = lingerDuration;
            isFiring = true;
        }
        
        //if(grabbedObject) grabbedObject.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        if (isFiring)
        {
            rb.AddForce((targetPosition - transform.position) * force, ForceMode2D.Impulse);
            curLinger -= Time.fixedDeltaTime;
            if (curLinger <= 0)
            {
                isFiring = false;
                rb.AddForce((mouthPosition.position - transform.position) * returnForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fly") && isFiring && !grabbedObject)
        {
            grabbedObject = other.gameObject;
            grabbedObject.transform.position = transform.position;
            HingeJoint2D newJoint = other.AddComponent<HingeJoint2D>();
            newJoint.connectedBody = rb;

            if (grabbedObject.GetComponent<FlyController>())
            {
                grabbedObject.GetComponent<FlyController>().canMove = false;
            }
        }
    }
}
