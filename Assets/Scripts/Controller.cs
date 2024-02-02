using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

    Rigidbody rb;
    
    int count = 0;
    bool isGrounded;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float flattenScale = 2f;

    Vector2 moveValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(moveValue.x, moveValue.y);
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        moveValue = direction;
        Move(direction.x, direction.y);
    }

    private void Move(float x, float z)
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);

    }

    void OnJump()
    {
        if(isGrounded)
        {
            Jump();
        }
        
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }

    void OnFlatten()
    {
        Flatten();
        Debug.Log(count);
    }

    private void Flatten()
    {
        if (count == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y / 2, transform.localScale.z * 2);
            count++;
            transform.position = new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z);
        }

        else
        {
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y * 2, transform.localScale.z / 2);
            count--;
        }
    }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                 isGrounded = true;
            Debug.Log(isGrounded);
        }

        private void OnCollisionExit(Collision thing)
        {
            if (thing.gameObject.CompareTag("Ground"))
                isGrounded = false;
            Debug.Log(isGrounded);
        }

        private void OnCollisionStay(Collision collision)
        {
        
        }
// you can compare the normal vectors of the collision and the ground so to see if the angle is too great to jump
    
}
