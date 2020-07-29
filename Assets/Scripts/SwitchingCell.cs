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
        Debug.Log("Setting cell material");
        if (cellType == CellType.Blue) {
            Material[] materials = new Material[1];
            materials[0] = blue;
            this.gameObject.GetComponent<MeshRenderer>().materials = materials;
        } else {
            Material[] materials = new Material[1];
            materials[0] = red;
            this.gameObject.GetComponent<MeshRenderer>().materials = materials;
        }
    }

    public override bool CellIs(CellType cellType)
    {
        return this.cellType == cellType || cellType == CellType.Any;
    }

    public override void TriggerCell()
    {
        Debug.Log("Cell is being triggered");
        if (cellType == CellType.Blue) {
            cellType = CellType.Red;
            Material[] materials = new Material[1];
            materials[0] = red;
            this.gameObject.GetComponent<MeshRenderer>().materials = materials;
        } else {
            cellType = CellType.Blue;
            Material[] materials = new Material[1];
            materials[0] = blue;
            this.gameObject.GetComponent<MeshRenderer>().materials = materials;
        }
    }
}
