using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCell : Cell
{
    public CellType cellType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CellIs(CellType cellType)
    {
        return this.cellType == cellType || cellType == CellType.Any;
    }
}
