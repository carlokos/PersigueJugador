using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rb;
    private float floatX;
    private float floatY;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        floatX = Input.GetAxis("Horizontal");
        floatY = Input.GetAxis("Vertical");

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitedSpeed = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
        }
    }

    private void FixedUpdate()
    {
        moveDirection = floatY * orientation.forward + orientation.right * floatX;
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }
}
