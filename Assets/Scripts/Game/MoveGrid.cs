using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrid : MonoBehaviour
{
    public bool isInit = false;

    MoveGridGizmos gridGizmos;

    public LevelControler Controler;

    WorldCell[,] cells;

    public void Init(LevelControler cont)
    {

        Controler = cont;
        gridGizmos = GetComponent<MoveGridGizmos>();

        gridGizmos.GridGizmosInit(this);

        if (Application.isPlaying)
        {
            GameInit();
            isInit = true;
        }

    }

    void GameInit()
    {
        cells = new WorldCell[Convert.ToInt32(Controler.LevelSettings.LevelSize.x), Convert.ToInt32(Controler.LevelSettings.LevelSize.y)];


        for (int i = 0; i < Controler.LevelSettings.LevelSize.x; i ++)
        {
            for (int j = 0; j < Controler.LevelSettings.LevelSize.y; j++)
            {
                Vector2 CellCenter = new Vector2((i) * Controler.GameSettings.CellSize.x + transform.position.x + (Controler.GameSettings.CellSize.x / 2), (j) * Controler.GameSettings.CellSize.y + transform.position.y + (Controler.GameSettings.CellSize.y / 2));
                Vector2 CellSize = new Vector2(Controler.GameSettings.CellSize.x / 2, Controler.GameSettings.CellSize.y / 2);
                cells[i, j] = new WorldCell(CellCenter, CellSize, new Vector2(i,j) , Controler, this);
            }

        }
    }

    void Start()
    {
        isInit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetSize()
    {
        Vector2 ret = new Vector2();

        if(Controler == null)
        {
            Debug.LogError("MoveGrid Not Init");
            return ret;
        }

        float x = Controler.LevelSettings.LevelSize.x * Controler.GameSettings.CellSize.x;
        float y = Controler.LevelSettings.LevelSize.y * Controler.GameSettings.CellSize.y;

        ret.x = x;
        ret.y = y;

        return ret;
    }

    public WorldCell GetNCell(Vector2 Dir, WorldCell point)
    {
        if(Dir == Vector2.up)
        {
            return ExistsOrNull(Convert.ToInt32(point.ID.x), Convert.ToInt32(point.ID.y + 1));
        }
        else if(Dir == Vector2.right)
        {
            return ExistsOrNull(Convert.ToInt32(point.ID.x + 1), Convert.ToInt32(point.ID.y));
        }
        else if(Dir == Vector2.down)
        {
            return ExistsOrNull(Convert.ToInt32(point.ID.x), Convert.ToInt32(point.ID.y - 1));
        }
        else if(Dir == Vector2.left)
        {
            return ExistsOrNull(Convert.ToInt32(point.ID.x - 1), Convert.ToInt32(point.ID.y));
        }

        Debug.LogError("Wrong Dir");
        return null;
    }

    WorldCell ExistsOrNull(int x,int y)
    {

        if(x < 0 || y < 0)
        {
            return null;
        }

        if(x >= cells.GetLength(0) || y >= cells.GetLength(1))
        {
            return null;
        }

        return cells[x, y];
    }
}
