using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Interactable
{
    public Bug thisBug;
    //bool is bug present? this way when we eat him once he is no longer there
    public bool didEatBug;

    //to add: if encounter is over and we decided to eat the bug
    public override void Interact()
    {
        GameManager.ins.stomach.Add(thisBug);
    }
}
