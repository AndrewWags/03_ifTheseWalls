using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable
{
    public bool state;

    public override void Interact()
    {
        base.Interact();

        state = !state;

        if(GetComponent<StateReactor>() != null)
        {
            GetComponent<StateReactor>().React();
        }

    }
}
