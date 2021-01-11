using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{

    public Vector2 CellSize;

    //Layers
    public LayerMask GroundLayer;
    public LayerMask WallLayer;
    public LayerMask EntityLayer;

}
