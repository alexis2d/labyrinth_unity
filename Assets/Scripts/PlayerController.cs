using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float runSpeedBoost = 2.5f;
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;
    private KeyCode forward = KeyCode.W;
    private KeyCode back = KeyCode.S;
    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;
    private Vector3 movement = Vector3.zero;
    private Camera playerCamera;
    private float rotationX = 0;
    private bool hasRun = false;
    
    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Look();
    }

    void Move()
    {
        if (Input.GetKey(forward)) {
            movement = Vector3.forward;
        }

        if (Input.GetKey(back)) {
            movement = Vector3.back;
        }

        if (Input.GetKey(right)) {
            movement = Vector3.right;
        }

        if (Input.GetKey(left)) {
            movement = Vector3.left;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed += runSpeedBoost;
            hasRun = true;
        }

        transform.Translate(speed * Time.fixedDeltaTime * movement);
        movement = Vector3.zero;

        if (hasRun == true) {
            speed -= runSpeedBoost;
            hasRun = false;
        }
    }

    void Look()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, - upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

}
