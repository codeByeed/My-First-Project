using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

    Rigidbody rb;
    Transform tr;
    int count = 0;
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
        Jump();
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
        }

        else
        {
            transform.localScale = new Vector3(transform.localScale.x/2, transform.localScale.y*2, transform.localScale.z/2);
            count--;
        }

    }
}
