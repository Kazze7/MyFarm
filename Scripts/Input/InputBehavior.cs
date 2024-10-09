public abstract class InputBehavior
{
    public virtual void Process()
    {
        Mouse();
        Keyboard();
    }
    public abstract void Mouse();
    public abstract void Keyboard();
}
