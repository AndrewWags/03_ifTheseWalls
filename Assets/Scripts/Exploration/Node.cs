using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public static Node current;

    public Transform cameraPosition;
    public List<Node> rechableNodes = new List<Node>();

    public bool ignoreCameraRotation;

    [HideInInspector]
    public Collider col;
    
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void OnMouseUp()
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        //Don't allow initiating travel to this node if we're already here
        if (current == this) return;

        current = this;

        //move camera
        if(ignoreCameraRotation == true)
        {
            GameManager.ins.rig.GoTo(cameraPosition);
        }
        else
        {
            GameManager.ins.rig.AlignTo(cameraPosition);
        }

        //turn off own collider
        if(col != null)
        {
            //if collider is enabled, turn it off
            col.enabled = false;
        }

        //turn on all reachable nodes colliders
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //turn off all reachable nodes colliders
        SetReachableNodes(false);
    }

    public void SetReachableNodes (bool set)
    {
        foreach (Node node in rechableNodes)
        {

            if (node.col != null)
            {
                if (GetComponent<Prereq>() && GetComponent<Prereq>().nodeAccess && !GetComponent<Prereq>().Complete)
                {
                    continue;
                }
                node.col.enabled = set;
            }
        }
    }
}
