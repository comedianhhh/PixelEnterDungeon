using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatePlayer : TurnBaseState
{
    public TurnStatePlayer(TurnManager context) : base(context) { }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        // Exit combat?
        if (DungeonManager.instance.CurrentRoom.Clear)
            SwitchState("Idle");
    }
}
