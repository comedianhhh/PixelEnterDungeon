using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateIdle : TurnBaseState
{
    public TurnStateIdle(TurnManager context) : base(context) { }

    public override void EnterState()
    {
        DungeonManager.instance.CurrentRoom.SetAllDoors(false);
    }

    public override void ExitState()
    {
        DungeonManager.instance.CurrentRoom.SetAllDoors(true);
    }

    public override void UpdateState()
    {
        // Enter combat?
        if (!DungeonManager.instance.CurrentRoom.Clear)
            SwitchState("Player");
    }
}
