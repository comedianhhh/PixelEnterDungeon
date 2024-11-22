using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatePlayer : TurnBaseState
{
    public TurnStatePlayer(TurnManager context) : base(context) { }

    public override void EnterState()
    {
        _ctx.PlayerUsedAction = false;
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        // Exit combat?
        if (DungeonManager.instance.CurrentRoom.Clear)
            SwitchState("Idle");

        // End player turn?
        if (_ctx.PlayerUsedAction)
            SwitchState("Enemy");
    }
}
