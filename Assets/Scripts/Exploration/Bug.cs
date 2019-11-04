using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : Node
{
    public Location loc;

    public DialogueTrigger dialogueTrigger;

    void Start()
    {

    }

    public override void Arrive()
    {
        base.Arrive();

        //make this object interactable if preq is met

        if (GetComponent<Prereq>() && !GetComponent<Prereq>().Complete)
        {
            return;
        }
        col.enabled = true;
        

        dialogueTrigger.TriggerDialogue();
    }

    public override void Leave()
    {
        base.Leave();
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
