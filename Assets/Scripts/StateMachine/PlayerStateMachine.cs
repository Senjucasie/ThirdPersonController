using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field:SerializeField]public PlayerInputReader InputReader { get; private set; }


    private void Start()
    {
        SwitchState(new PlayerTeststate(this));
    }
}
