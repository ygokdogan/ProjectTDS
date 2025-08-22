using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerControls playerControls;

    public Vector2 MoveInput { get; private set; }
    public Vector2 AimInput { get; private set; }
    public bool TestInput { get; private set; }
    
    private void Awake()
    {
        playerControls = new PlayerControls();
        
        playerControls.Gameplay.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Movement.canceled += ctx => MoveInput = Vector2.zero;
        
        playerControls.Gameplay.Aim.performed += ctx => AimInput = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Aim.canceled += ctx => AimInput = Vector2.zero;
        
        playerControls.Gameplay.Test.performed += ctx => TestInput = true;
        playerControls.Gameplay.Test.canceled += ctx => TestInput = false;
    }

    public void UseTestInput() => TestInput = false;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
