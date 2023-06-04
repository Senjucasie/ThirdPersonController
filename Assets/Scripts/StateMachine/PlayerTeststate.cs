using UnityEngine;

public class PlayerTeststate : PlayerBaseState
{
    public PlayerTeststate(PlayerStateMachine playerstatemachine) : base(playerstatemachine) { }

    private Vector3 _movePosition = Vector3.zero;
    private Vector2 _moveInput;

    public override void Enter()
    {
        Debug.Log("Enter");
        _playerStateMachine.InputReader.OnJumpEvent += OnJump;
    }

    public override void Tick(float deltatime)
    {
        _moveInput = _playerStateMachine.InputReader.MoveInput;

        if (_moveInput == Vector2.zero)
        {
            _playerStateMachine.PlayerAnimator.SetFloat("FreeMove", 0, 0.1f, deltatime);
            return;
        }

        _movePosition.x = _moveInput.x;
        _movePosition.z = _moveInput.y;
        _playerStateMachine.CharacterControl.Move(_movePosition * deltatime * _playerStateMachine.MoveSpeed);
        _playerStateMachine.PlayerAnimator.SetFloat("FreeMove", 1, 0.1f, deltatime);
        _playerStateMachine.transform.rotation = Quaternion.LookRotation(_movePosition);
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
