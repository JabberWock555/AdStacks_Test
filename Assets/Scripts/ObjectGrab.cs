using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    private Rigidbody body;
    private Transform grabPoint;
    private float speed = 10f;
    private Rigidbody previewBody;
    private GameObject preview;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Grab(Transform _grabPoint) 
    {
        if (grabPoint == null)
        {
            grabPoint = _grabPoint;
            body.useGravity = false;
            body.freezeRotation = true;
            body.mass = 0;
        }
    }

    public void Drop()
    {
        if (preview != null && PreviewController.dropable)
        {
            Transform previewTrasform = preview.transform;
            endPreview();

            grabPoint = null;
            body.useGravity = true;
            body.mass = 1;
            gameObject.transform.SetPositionAndRotation(previewTrasform.position, previewTrasform.rotation);
            body.constraints = RigidbodyConstraints.FreezeAll;
        }

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

    Vector3 direction;

    public void showPreview(float dropDistance, Transform cameraTransform, PreviewController previewPrefab)
    {

        if (preview == null)
        {
            direction = cameraTransform.position + cameraTransform.forward * dropDistance;
            Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
            preview= Instantiate(previewPrefab.gameObject, direction, rotation, cameraTransform);
            previewBody = preview.GetComponent<Rigidbody>();
            previewBody.isKinematic = true;
        }
    }

    public void endPreview()
    {
        if (preview != null)
        {
            Destroy(preview);
            preview = null;
        }
    }

    public bool isPreviewON()
    {
        return preview;
    }
}
