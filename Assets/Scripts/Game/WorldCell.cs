using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCell
{
    public Vector2 Pos;

    public Vector2 Size;

    public Vector2 ID;

    public CellType Type;

    LevelControler controler;

    MoveGrid gridParnet;

    public Entity entitity;

    public WorldCell(Vector2 pos, Vector2 size, Vector2 id, LevelControler Controler, MoveGrid GridParnet)
    {
        Pos = pos;
        Size = size;
        controler = Controler;
        gridParnet = GridParnet;
        ID = id;

        Init();
    }

    void Init()
    {
        if(Physics2D.OverlapBox(Pos, Size, 0, controler.GameSettings.GroundLayer))
        {
            Type = CellType.Ground;
        }

        if(Physics2D.OverlapBox(Pos, Size, 0, controler.GameSettings.WallLayer))
        {
            Type = CellType.Wall;
        }

        Collider2D hit = Physics2D.OverlapBox(Pos, Size, 0, controler.GameSettings.EntityLayer);
        if (hit)
        {
            Entity ent = hit.GetComponent<Entity>();
            if(ent != null)
            {
                ent.Init(controler,this);
                entitity = ent;
            }
        }


    }

    public WorldCell GetNCell(Vector2 Direct)
    {
        return gridParnet.GetNCell(Direct, this);
    }
}
