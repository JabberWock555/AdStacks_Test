using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    private Rigidbody body;
    private Transform grabPoint;
    private float speed = 10f;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Grab(Transform _grabPoint) 
    {
        grabPoint = _grabPoint;
        body.useGravity = false;
        body.freezeRotation = true;
        body.mass = 0;
    }

    public void Drop()
    {
        grabPoint = null;
        body.useGravity = true;
        body.freezeRotation = true;
        body.mass = 1;
    }

    private void FixedUpdate()
    {
        if(grabPoint != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, grabPoint.position, speed * Time.deltaTime);
            body.MovePosition(newPos);
            body.MoveRotation(grabPoint.rotation);
        }
    }
}
