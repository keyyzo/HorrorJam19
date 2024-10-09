using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{

    [Header("Character Controller Variable")]
    [SerializeField] private CharacterController characterController;

    [Space(10)]

    [Header("Ground Check Components")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Space(10)]

    [Header("Alternate Ground Check Components")]

    [SerializeField] private Vector3 boxSize;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    // private Ground Check Variables
    bool isGrounded;

    [Space(10)]

    [Header("Movement Variables")]
    [SerializeField] private float baseMoveSpeed = 10f;
    [SerializeField] private float gravitySpeed = -9.81f;

    [Space(10)]

    [Header("Jump Variables")]
    [SerializeField] private float jumpHeight = 3f;

    // Velocity components

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moved code from update into its own function to be called from PlayerController
        // Will review and move back if necessary
        
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);
        ////RaycastHit hit;
        ////float radius = 5f;
        ////Ray landingRay = new Ray(groundCheck.position, Vector3.down);

        ////isGrounded = Physics.SphereCast(landingRay, radius, out hit,2f);
        //isGrounded = Physics.BoxCast(groundCheck.position, transform.localScale, Vector3.down);

       
        

        ////isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);

        //GroundedReset();

        //BaseMovement();

        //if (Input.GetButtonDown("Jump") && GroundCheck())
        //{
        //    Jump();
        //}

        //ApplyVelocity();
    }

    public void MovementUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);
        //RaycastHit hit;
        //float radius = 5f;
        //Ray landingRay = new Ray(groundCheck.position, Vector3.down);

        //isGrounded = Physics.SphereCast(landingRay, radius, out hit,2f);
        isGrounded = Physics.BoxCast(groundCheck.position, transform.localScale, Vector3.down);




        //isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);

        GroundedReset();

        BaseMovement();

        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            Jump();
        }

        ApplyVelocity();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheck.position - groundCheck.up * maxDistance, boxSize);
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

    bool GroundCheck()
    {

        if (Physics.CheckBox(groundCheck.position, boxSize, transform.rotation,layerMask))
        {
            return true;  
        }

        else
        {
            return false;
        }

        //if (Physics.CheckSphere(groundCheck.position, groundDistance))
        //{
        //    return true;
        //}

        //else
        //{
        //    return false;
        //}
    }


    void GroundedReset()
    {
        if (GroundCheck() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void Jump()
    {
       
         velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravitySpeed);
        
    }

    void BaseMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * baseMoveSpeed * Time.deltaTime);
    }

    void ApplyVelocity()
    {
        velocity.y += gravitySpeed * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

   
}
