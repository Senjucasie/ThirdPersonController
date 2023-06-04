using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field:SerializeField]public PlayerInputReader InputReader { get; private set; }

    [field: SerializeField]public CharacterController CharacterControl { get; private set; }

    [field: SerializeField]public Animator PlayerAnimator { get; private set; }

    [field: SerializeField] public float MoveSpeed { get; private set; }

    [field: SerializeField] public float RotationSpeed { get; private set; }

    public Transform CameraTransform { get; private set; }


    private void Start()
    {
        CameraTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this));
    }
}
