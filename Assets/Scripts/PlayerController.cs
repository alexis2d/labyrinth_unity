using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private KeyCode forward = KeyCode.W;
    private KeyCode back = KeyCode.S;
    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;

    private Vector3 movement = Vector3.zero;
    
    void FixedUpdate()
    {
        Move();
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

        transform.Translate(speed * Time.fixedDeltaTime * movement);
        movement = Vector3.zero;
    }

    void Look()
    {
        // TODO
    }

}
