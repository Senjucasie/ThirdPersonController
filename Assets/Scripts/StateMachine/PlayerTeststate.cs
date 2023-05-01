using UnityEngine;

public class PlayerTeststate : PlayerBaseState
{
    public PlayerTeststate(PlayerStateMachine playerstatemachine) : base(playerstatemachine) { }

    private Vector3 _movePosition = Vector3.zero;

    public override void Enter()
    {
        Debug.Log("Enter");
        _playerStateMachine.InputReader.OnJumpEvent += OnJump;
    }

    public override void Tick(float deltatime)
    {
        Vector2 moveinput = _playerStateMachine.InputReader.MoveInput;
        _movePosition.x = moveinput.x;
        _movePosition.z = moveinput.y;
        _playerStateMachine.transform.Translate(_movePosition * deltatime);  
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
