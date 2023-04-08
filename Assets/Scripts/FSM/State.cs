public abstract class State
{
    public StateParameters attributes;

    public abstract void ExecuteState();

    public abstract State CheckForTransition();
}