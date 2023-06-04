using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    public PlayerFreeLookState(PlayerStateMachine playerstatemachine) : base(playerstatemachine) { }

    private readonly int _playerFreeLook=Animator.StringToHash("FreeMove");

    private const float AnimatorDamp=0.1f;

    private Vector3 _movePosition;

    public override void Enter()
    {
        Debug.Log("Enter");
        _playerStateMachine.InputReader.OnJumpEvent += OnJump;
    }

    public override void Tick(float deltatime)
    {
        _movePosition = CalculateMoveVector(_playerStateMachine.CameraTransform.forward, 
                                            _playerStateMachine.CameraTransform.right, 
                                            _playerStateMachine.InputReader.MoveInput);

        if (_movePosition == Vector3.zero)
        {
            _playerStateMachine.PlayerAnimator.SetFloat(_playerFreeLook, 0, AnimatorDamp, deltatime);
            return;
        }

        _playerStateMachine.CharacterControl.Move(_movePosition * deltatime * _playerStateMachine.MoveSpeed);
        _playerStateMachine.PlayerAnimator.SetFloat(_playerFreeLook, 1, AnimatorDamp, deltatime);

        FaceMovementDirection(deltatime);
    }

    private void FaceMovementDirection(float deltatime)
    {
        _playerStateMachine.transform.rotation = Quaternion.Lerp(_playerStateMachine.transform.rotation, 
                                                                Quaternion.LookRotation(_movePosition)
                                                                ,deltatime*_playerStateMachine.RotationSpeed);
    }

    public override void Exit()
    {
        Debug.Log("Exit");

        _playerStateMachine.InputReader.OnJumpEvent -= OnJump;
    }

    private void OnJump()
    {
        _playerStateMachine.SwitchState(new PlayerFreeLookState(_playerStateMachine));
    }

    private Vector3 CalculateMoveVector( Vector3 forwardcamdir,Vector3 rightcamdir, Vector2 keyinput)
    {
        if (forwardcamdir == Vector3.zero || rightcamdir == Vector3.zero)
            return Vector3.zero;

        forwardcamdir.y = 0;
        rightcamdir.y = 0;
        forwardcamdir = forwardcamdir.normalized;
        rightcamdir = rightcamdir.normalized;

        return forwardcamdir * keyinput.y + rightcamdir * keyinput.x;
    }
}
