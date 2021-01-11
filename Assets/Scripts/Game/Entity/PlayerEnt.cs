using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnt : Entity
{
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMove(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMove(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove(Vector2.down);
        }
    }

    void PlayerMove(Vector2 move)
    {

        WorldCell cellToMove = base.cell.GetNCell(move);

        if(cellToMove != null)
        {
            if (cellToMove.Type == CellType.Ground)
            {
                if (cellToMove.entitity == null)
                {
                    MoveTo(cellToMove);
                }
                else
                {
                    cellToMove.entitity.Action(this, move);
                }
            }
        }
    }
}
