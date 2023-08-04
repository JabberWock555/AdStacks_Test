using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform orientation;
    [SerializeField] private float moveSpeed;

    private float horizontal;
    private float vertical;

    private Vector3 moveDirection;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void getInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        if(horizontal != 0 || vertical != 0)
        {
            moveDirection = orientation.forward * vertical + orientation.right * horizontal;
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }
    }
}
