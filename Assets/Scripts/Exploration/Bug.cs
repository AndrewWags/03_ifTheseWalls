using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : Node
{
    public Location loc;
    Encounter encont;

    void Start()
    {
        encont = GetComponent<Encounter>();
    }

    public override void Arrive()
    {
        if (encont != null && encont.enabled)
        {
            encont.BugEncount();
            return;
        }

        base.Arrive();

        //make this object interactable if preq is met
        if (encont != null)
        {
            if (GetComponent<Prereq>() && !GetComponent<Prereq>().Complete)
            {
                return;
            }
            col.enabled = true;
            encont.enabled = true;
        }
    }

    public override void Leave()
    {
        base.Leave();

        if (encont != null)
        {
            encont.enabled = false;
        }
    }

    //Change cursor on mouse over colider
    private void OnMouseEnter()
    {
        CursorController.Instance.SetWallCursor();
    }

    //Change cursor on mouse over colider
    private void OnMouseExit()
    {
        CursorController.Instance.SetNormalCursor();
    }
}
