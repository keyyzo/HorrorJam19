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
    [SerializeField] PlayerInput m_PlayerInput;
    [SerializeField] PlayerAudio m_PlayerAudio;

    private void Awake()
    {
        Initialize();
    }


    private void Initialize()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerInput = GetComponent<PlayerInput>();
        m_PlayerAudio = GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        m_PlayerMovement.MovementUpdate();
    }

}
