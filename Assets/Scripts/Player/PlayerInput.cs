using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerInput : MonoBehaviour
{
    [Header("Input Action Assest")]

    [SerializeField] private InputActionAsset PlayerControls;

    // List of InputActions for player character input

    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction jumpAction;
    private InputAction crouchAction;
    private InputAction lookAction;
    private InputAction sprintAction;

    // Vector2 inputs 

    private Vector2 moveInput;
    private Vector2 lookInput;

    private void Awake()
    {
        moveAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Move");
        interactAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Interact");
        jumpAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Jump");
        crouchAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Crouch");
        lookAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Look");
        sprintAction = PlayerControls.FindActionMap("PlayerInputControls").FindAction("Sprint");

    }

    private void OnEnable()
    {
        moveAction.Enable();
        interactAction.Enable();
        jumpAction.Enable();
        crouchAction.Enable();
        lookAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        interactAction.Disable();
        jumpAction.Disable();
        crouchAction.Disable();
        lookAction.Disable();
        sprintAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
