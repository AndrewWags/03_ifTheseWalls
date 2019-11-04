﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : Node
{
    public static Location current;

    //Change cursor on mouse over colider
    private void OnMouseEnter()
    {
        CursorController.Instance.SetMoveCursor();
    }

    //Change cursor on mouse over colider
    private void OnMouseExit()
    {
        CursorController.Instance.SetNormalCursor();
    }

    public override void Arrive()
    {
        base.Arrive();

        current = this;
    }
}
