using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode up;
    public KeyCode right;
    public KeyCode down;
    public KeyCode left;
    public float buttonDelay;
    private float buttonWait;
    private Cell location;

    void Update()
    {
        CheckInputs();
    }

    public void MoveTo(Cell location)
    {
        this.location = location;
        transform.position = location.transform.position;
        buttonWait = buttonDelay;
        location.TriggerCell();
    }

    private void CheckInputs()
    {
        if (buttonWait > 0.0f) {
            buttonWait -= Time.deltaTime;
            return;
        }
        if (Input.GetKey(up) && !Input.GetKey(down) && location.above && location.above.CanMove()) {
            MoveTo(location.above);
        } else if (Input.GetKey(down) && !Input.GetKey(up) && location.below && location.below.CanMove()) {
            MoveTo(location.below);
        } else if (Input.GetKey(left) && !Input.GetKey(right) && location.left && location.left.CanMove()) {
            MoveTo(location.left);
        } else if (Input.GetKey(right) && !Input.GetKey(left) && location.right && location.right.CanMove()) {
            MoveTo(location.right);
        }
    }
}
