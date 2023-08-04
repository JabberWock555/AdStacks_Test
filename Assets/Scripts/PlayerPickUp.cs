using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float pickUpDistance;
    [SerializeField] private LayerMask layerMask;

    private ObjectGrab objectGrab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (objectGrab == null)
            {
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, layerMask))
                {
                    if (raycastHit.transform.TryGetComponent<ObjectGrab>(out objectGrab))
                    {
                        objectGrab.Grab(grabPoint);
                    }
                }
            }
            else
            {
                objectGrab.Drop();
            }
        }
    }
}
