using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(PlayerInput),typeof(PlayerMovement),typeof(PlayerAudio))]
public class PlayerController : MonoBehaviour
{
    // Components for handling different aspects of the player functionality
    

    [SerializeField] PlayerMovement m_PlayerMovement;
    public PlayerMovement playerMovement => m_PlayerMovement;

    [SerializeField] PlayerInput m_PlayerInput;
    public PlayerInput playerInput => m_PlayerInput;  

    [SerializeField] PlayerAudio m_PlayerAudio;
    public PlayerAudio playerAudio => m_PlayerAudio;

    // Creating the Player State Machine, which will be initialized on Awake

    private PlayerStateMachine m_PlayerStateMachine;
    public PlayerStateMachine playerStateMachine => m_PlayerStateMachine;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        m_PlayerStateMachine.Initialize(m_PlayerStateMachine.idleState);
    }


    private void Initialize()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerInput = GetComponent<PlayerInput>();
        m_PlayerAudio = GetComponent<PlayerAudio>();

        m_PlayerStateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        m_PlayerMovement.MovementUpdate();
    }

}
