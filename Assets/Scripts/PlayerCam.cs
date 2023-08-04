using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private Transform Orientation;
    [SerializeField] private Transform cameraPos;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = cameraPos.position;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speedY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, Quaternion.identity.z);
        Orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
