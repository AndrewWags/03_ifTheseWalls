using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTrigger : MonoBehaviour
{
    public Encounter dialogue;

    public void Activate()
    {
        EncounterManager.instance.StartEncounter(dialogue);
    }
}
