using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field:SerializeField]public PlayerInputReader InputReader { get; private set; }

    [field: SerializeField]public CharacterController CharacterControl { get; private set; }

    [field: SerializeField] public float MoveSpeed { get; private set; }


    private void Start()
    {
        SwitchState(new PlayerTeststate(this));
    }
}
