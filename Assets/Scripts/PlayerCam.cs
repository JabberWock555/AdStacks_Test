using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private Transform Orientation;
    [SerializeField] private Transform cameraPos;

    private float xRotation;
    private float yRotation;
    private float mouseX;
    private float mouseY;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }


    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = cameraPos.position;

        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speedY;


            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, Quaternion.identity.z);
            Orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            mouseX = joystick.Horizontal * Time.deltaTime * speedX;
            mouseY = joystick.Vertical * Time.deltaTime * speedY;

        }


        
    }
}
