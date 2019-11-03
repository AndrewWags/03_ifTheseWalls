using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bug))]
public abstract class Encounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public virtual void BugEncount()
    {
        Debug.Log("Encountering " + name);
    }
}
