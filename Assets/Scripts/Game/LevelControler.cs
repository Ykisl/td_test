using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelControler : MonoBehaviour
{

    public LevelSettings LevelSettings;
    public GameSettings GameSettings;

    public MoveGrid MoveGrid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveGrid != null)
        {
            if(MoveGrid.isInit == false)
            {
                MoveGrid.Init(this);
            }
        }
    }
}
