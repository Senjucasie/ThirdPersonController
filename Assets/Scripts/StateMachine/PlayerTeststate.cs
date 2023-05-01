using UnityEngine;

public class PlayerTeststate : PlayerBaseState
{
    public PlayerTeststate(PlayerStateMachine playerstatemachine) : base(playerstatemachine) { }
    

    public override void Enter()
    {
        Debug.Log("Enter");
        _playerStateMachine.InputReader.OnJumpEvent += OnJump;
    }

    public override void Tick(float deltatime)
    {
        
        //Debug.Log($"remainingtime{_remainingTime}");
       
    }

    public override void Exit()
    {
        Debug.Log("Exit");

    _playerStateMachine.InputReader.OnJumpEvent -= OnJump;
    }

    private void OnJump()
    {
        _playerStateMachine.SwitchState(new PlayerTeststate(_playerStateMachine));
    }
}
