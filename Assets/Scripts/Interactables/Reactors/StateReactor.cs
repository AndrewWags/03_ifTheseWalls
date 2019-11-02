using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Switcher))]
public abstract class StateReactor : MonoBehaviour
{
    protected Switcher switcher;

    protected virtual void Awake()
    {
        switcher = GetComponent<Switcher>();
    
    }

    public virtual void React()
    {
        Debug.Log(name + "'s state is" + switcher.state);
    }
}
