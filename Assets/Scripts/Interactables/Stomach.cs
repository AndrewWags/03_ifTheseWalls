using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : Interactable
{
    public Bug[] eattenBugs;

    public override void Interact()
    {
        GameManager.ins.bugsEatten = eattenBugs;
    }
}
