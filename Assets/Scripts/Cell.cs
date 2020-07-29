using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell above;
    public Cell right;
    public Cell below;
    public Cell left;

    public virtual bool CellIs(CellType cellType)
    {
        return true;
    }
}
