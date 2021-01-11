using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected WorldCell cell;

    LevelControler controler;

    public void Init(LevelControler Controler, WorldCell Cell)
    {
        MoveTo(Cell);
        controler = Controler;
    }

    public void MoveTo(WorldCell Cell)
    {
        if (Cell != null)
        {
            if (cell != null)
            {
                cell.entitity = null;
            }

            transform.position = Cell.Pos;
            cell = Cell;

            Cell.entitity = this;
        }
    }

    public virtual void Action(Entity sendner, Vector2 direct)
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
