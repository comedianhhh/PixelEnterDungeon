using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatePlayer : TurnBaseState
{
    public TurnStatePlayer(TurnManager context) : base(context) { }

    public override void EnterState()
    {
        _ctx.PlayerUsedAction = false;
        ArtifactManager.instance.TriggerStartOfTurn();
    }

    public override void ExitState()
    {
        ArtifactManager.instance.TriggerEndOfTurn();
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
