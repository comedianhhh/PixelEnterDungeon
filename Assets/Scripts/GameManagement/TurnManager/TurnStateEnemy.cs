using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateEnemy : TurnBaseState
{
    public TurnStateEnemy(TurnManager context) : base(context) { }

    // Variables
    List<EC_Damage> _hostiles = new List<EC_Damage>();

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
