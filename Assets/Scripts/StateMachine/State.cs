

public abstract class State
{
    public abstract void Enter();

    public abstract void Tick(float deltatime);

    public abstract void Exit();

}