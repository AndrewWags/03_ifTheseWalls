using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEncounter : Encounter
{
    public Sprite pic;

    public override void BugEncount()
    {
        EncounterManager.instance.view.Activate(pic);
    }
}
