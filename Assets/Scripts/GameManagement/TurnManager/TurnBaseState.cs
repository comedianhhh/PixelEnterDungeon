public abstract class TurnBaseState
{
    protected TurnManager _ctx;

    public TurnBaseState(TurnManager context)
    {
        _ctx = context;
    }

    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void UpdateState();

    public void SwitchState(string id)
    {
        ExitState();
        _ctx.CurrentState = _ctx.states[id];
        _ctx.CurrentState.EnterState();
    }
}

/***************************************** TEMPLATE *****************************************/
public class TurnStateTemplate : TurnBaseState
{
    public TurnStateTemplate(TurnManager context) : base(context) { }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }
}