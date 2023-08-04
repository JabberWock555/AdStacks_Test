using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float pickUpDistance;
    [SerializeField] private float dropDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask CartMask;
    [SerializeField] private PreviewController preview;

    private ObjectGrab objectGrab;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || UiManager.Instance.PickUp())
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
                objectGrab = null;
            }
        }

        if (UiManager.Instance.DropDown())
        {
            if (objectGrab != null)
            {
                objectGrab.Drop();
                objectGrab = null;
            }
        }

        if (objectGrab != null)
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycast, dropDistance, CartMask))
            {
                float distance = raycast.distance;
                if (!objectGrab.isPreviewON())
                {
                    objectGrab.showPreview(distance, cameraTransform, preview);
                }
                else
                {
                    objectGrab.endPreview();

                }
            }
        }
    }
}
