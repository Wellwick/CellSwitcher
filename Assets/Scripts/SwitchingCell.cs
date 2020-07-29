using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCell : Cell
{
    public CellType cellType;
    public Material blue;
    public Material red;
    // Start is called before the first frame update
    void Start()
    {
        if (cellType == CellType.Blue) {
            ChangeMaterial(blue);
        } else {
            ChangeMaterial(red);
        }
    }

    public override bool CellIs(CellType cellType)
    {
        return this.cellType == cellType || cellType == CellType.Any;
    }

    public override void TriggerCell()
    {
        if (cellType == CellType.Blue) {
            cellType = CellType.Red;
            ChangeMaterial(red);
        } else {
            cellType = CellType.Blue;
            ChangeMaterial(blue);
        }
        grid.RecalculateDoors();
    }
}
