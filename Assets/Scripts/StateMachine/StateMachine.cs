using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{

    private State _currentState;

    void Update()
    {
        _currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newstate)
    {
        if( newstate==null)
        {
            Debug.LogError($"newstate is null{newstate}");
            return;
        }
        _currentState?.Exit();
        _currentState = newstate;
        _currentState.Enter();
    }
}
