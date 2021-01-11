using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnt : Entity
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Action(Entity sendner, Vector2 direct)
    {
        WorldCell cellToMove = base.cell.GetNCell(direct);

        WorldCell BaseCell = cell;

        if (cellToMove != null)
        {
            if (cellToMove.Type == CellType.Ground && cellToMove.entitity == null)
            {
                MoveTo(cellToMove);
                sendner.MoveTo(BaseCell);
            }
        }
    }
}
