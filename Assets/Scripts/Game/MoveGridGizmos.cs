using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveGridGizmos : MonoBehaviour
{
    MoveGrid Grid;

    Vector2 center;

    public bool DrawCell;
    public bool DrawBox;

    public void GridGizmosInit(MoveGrid grid)
    {
        Grid = grid;
    }

    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (Grid != null)
        {
            Vector2 size = Grid.GetSize();
            if (DrawBox)
            {
                center = new Vector2(transform.position.x + (size.x / 2), transform.position.y + (size.y / 2));

                Gizmos.DrawWireCube(center, size);
            }

            if (DrawCell)
            {
                for (float i = 0; i < size.x; i += Grid.Controler.GameSettings.CellSize.x)
                {
                    for (float j = 0; j < size.y; j += Grid.Controler.GameSettings.CellSize.y)
                    {
                        Vector2 CellCenter = new Vector2(i + transform.position.x + (Grid.Controler.GameSettings.CellSize.x / 2), j + transform.position.y + (Grid.Controler.GameSettings.CellSize.y / 2));
                        Gizmos.DrawWireCube(CellCenter, Grid.Controler.GameSettings.CellSize);
                    }
                }
            }
            
        }
    }
}
