using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] float speed = 6;
    [SerializeField] float jumpForce = 8;

    public bool isSprinting = false;
    public float sprintingMultiplier;

    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(new Vector3(x, 0, z));

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0, 1.8934f, -31);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            if (speed == 6)
            {
                speed = 4.7f;
            }
            else
            {
                speed = 4.7f;
            }
        }
        else
        {
            isSprinting = false;
        }
        if (isSprinting == false)
        {
           speed = 3;
        }
    }  
    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
