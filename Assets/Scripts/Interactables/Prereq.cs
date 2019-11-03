using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prereq : MonoBehaviour
{
    public Switcher watchSwitcher;
    public bool nodeAccess;
    //for more functionality
    //public bool state we want 

    public bool Complete
    {
        get
        {return watchSwitcher.state;}
        //get return {return watchSwitcher.state == watchSwitcher.statewewant;}
    }
}
