using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Node startingNode;

    //create an array or list to add or subtract from in order to have multiple bugs
    //when you click on a collector that has an item attached to it, you will basically poulate it into this item held location
    public List<BugCounter> stomach = new List<BugCounter>();

    public CameraRig rig;

    void Awake()
    {
        //very bad singleton, refresh and look up later
        ins = this;
    }

    void Start()
    {
        startingNode.Arrive();
    }

    void Update()
    {
        //If I right click, and im in a prop, then backup to the props location
        if (Input.GetMouseButtonDown(1))
        {
            ReturnToLocation();
        } 
    }

    void ReturnToLocation()
    {
        EncounterManager.instance.EndEncounter();
        Location.current.Arrive();
    }

}
