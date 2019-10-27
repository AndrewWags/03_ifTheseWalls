﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> rechableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        Arrive();
    }

    public void Arrive()
    {
        //leave existing currentNode
        if(GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }
        
        //set current node
        GameManager.ins.currentNode = this;

        //move camera
        GameManager.ins.rig.AlignTo(cameraPosition);

        //turn off own collider
        if(col != null)
        {
            //if collider is enabled, turn it off
            col.enabled = false;
        }

        //turn on all reachable nodes colliders
        foreach(Node node in rechableNodes)
        {
            if(node.col != null)
            {
                node.col.enabled = true;
            }
        }
    }

    public void Leave()
    {
        //turn off all reachable nodes colliders
        foreach (Node node in rechableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
