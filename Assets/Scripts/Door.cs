using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Wall
{
    public CellType doorType;
    public Grid grid;

    public bool isOpen()
    {
        return grid.CellsAreAll(doorType);
    }
}
