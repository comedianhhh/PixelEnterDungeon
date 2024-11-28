using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateEnemy : TurnBaseState
{
    public TurnStateEnemy(TurnManager context) : base(context) { }

    // Variables
    List<EC_Damage> _hostiles = new List<EC_Damage>();
    float _timeSinceAttack;

    public override void EnterState()
    {
        _hostiles = DungeonManager.instance.CurrentRoom.GetHostiles();
        _timeSinceAttack = 0;
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if (_hostiles.Count > 0 && _timeSinceAttack >= _ctx.timeBetweenAttacks)
        {
            // Attack
            _hostiles[0].Attack();
            _hostiles.RemoveAt(0);
            _timeSinceAttack = 0;
        }

        // Exit combat?
        if (DungeonManager.instance.CurrentRoom.Clear)
        {
            ArtifactManager.instance.TriggerClearRoom();
            SwitchState("Idle");
            return;
        }

        // Player turn?
        if (_hostiles.Count <= 0)
        {
            SwitchState("Player");
            return;
        }

        // Timers
        _timeSinceAttack += Time.deltaTime;
    }
}
