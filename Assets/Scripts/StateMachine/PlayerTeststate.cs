
using UnityEngine;

public class PlayerTeststate : PlayerBaseState
{
    public PlayerTeststate(PlayerStateMachine playerstatemachine) : base(playerstatemachine) { }

    private  float _remainingTime = 5;
    

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltatime)
    {
        _remainingTime -= deltatime;
        Debug.Log($"remainingtime{_remainingTime}");
        if(_remainingTime <= 0)
        {
            _playerStateMachine.SwitchState(new PlayerTeststate(_playerStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }

    
}
