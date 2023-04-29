public abstract class PlayerBaseState:State
{
    protected PlayerStateMachine _playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerstatemachine)
    {
        this._playerStateMachine = playerstatemachine;
    }
}
