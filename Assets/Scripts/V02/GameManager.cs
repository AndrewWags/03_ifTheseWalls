using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    [HideInInspector]
    public Node currentNode;

    //very bad singleton, refresh and look up later
    void Awake()
    {
        ins = this;
    }

    void Update()
    {
       if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        } 
    }

}
