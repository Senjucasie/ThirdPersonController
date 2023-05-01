using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MoveInput { get; private set; }

    public event Action OnJumpEvent;
    public event Action OnDodgeEvent;

    private Controls _control;

    private void Start()
    {
        InitControls();
    }

    private void InitControls()
    {
        _control = new Controls();
        _control.Player.SetCallbacks(this);
        _control.Enable();
    }

    private void OnDestroy()
    {
        _control.Disable(); 
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnJumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnDodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
