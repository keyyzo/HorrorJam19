using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [Header("Sensitivity Components")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform orientation;

    [Space(10)]

    [Header("Rotation Limits Components")]
    [SerializeField] private float lookXLimits = 90f;

    // private variables for sensitivity

    float xRotation = 0f;
    float yRotation;


    // Required Components

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -lookXLimits, lookXLimits);

        // rotate camera and orientation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
