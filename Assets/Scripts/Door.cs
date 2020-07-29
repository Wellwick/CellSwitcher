using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Wall
{
    public CellType doorType;
    public Material closed;
    public Material open;

    private bool wasOpen = false;

    void Start()
    {
        if (IsOpen()) {
            wasOpen = true;
            ChangeMaterial(open);
        } else {
            wasOpen = false;
            ChangeMaterial(closed);
        }
    }

    public bool IsOpen()
    {
        return grid.CellsAreAll(doorType);
    }

    public void CheckOpen()
    {
        if (IsOpen() && !wasOpen) {
            wasOpen = true;
            ChangeMaterial(open);
        } else if (wasOpen && !IsOpen()) {
            wasOpen = false;
            ChangeMaterial(closed);
        }
    }
}
