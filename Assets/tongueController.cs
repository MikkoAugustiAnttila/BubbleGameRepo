using System;
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
    
    
    void Update()
    {
        
        if(Input.GetMouseButton(0) && !isFiring)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            targetPosition = mouseWorldPos;
            curLinger = lingerDuration;
            isFiring = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFiring)
        {
            rb.AddForce((targetPosition - transform.position) * force, ForceMode2D.Impulse);
            curLinger -= Time.fixedDeltaTime;
            Debug.Log(curLinger);
            if (curLinger <= 0)
            {
                isFiring = false;
                rb.AddForce((mouthPosition.position - transform.position) * returnForce, ForceMode2D.Impulse);
            }
        }
    }
}
