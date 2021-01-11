using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Settings/LevelSettings", order = 1)]
public class LevelSettings : ScriptableObject
{
    public Vector2 LevelSize;
}
