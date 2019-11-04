using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    public Location loc;
    public EncounterTrigger encounterTrigger;

    Interactable inter;

    void Start()
    {
        inter = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if(inter != null && inter.enabled)
        {
            inter.Interact();
            return;
        }

        base.Arrive();

        if (encounterTrigger != null) encounterTrigger.Activate();

        ////make this object interactable if preq is met
        //if(inter != null)
        //{
        //    if(GetComponent<Prereq>() && !GetComponent<Prereq>().Complete)
        //    {
        //        return;
        //    }
        //    col.enabled = true;
        //    inter.enabled = true;
        //}
    }

    public override void Leave()
    {
        base.Leave();

        if(inter != null)
        {
            inter.enabled = false;
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
