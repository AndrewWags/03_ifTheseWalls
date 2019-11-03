using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prereq : MonoBehaviour
{
    //if true, check from bugs instead
    public bool requiredBugs;
    
    //watch this switcher
    public Switcher watchSwitcher;

    //if requiredBugs is true, we'll check this collector
    public Collector checkCollector;

    //if true, then block access altogether
    public bool nodeAccess;

    //for more functionality
    //public bool state we want 

    //check if prereq is met
    public bool Complete
    {
        get
        {
            if (!requiredBugs)
            {
                return watchSwitcher.state;
            }
            else
            {
                //return GameManager.ins.bugEatten.bugName == checkCollector.thisBug.bugName;
                return !watchSwitcher.state;
            }

        }
        //get return {return watchSwitcher.state == watchSwitcher.statewewant;}
    }
}
