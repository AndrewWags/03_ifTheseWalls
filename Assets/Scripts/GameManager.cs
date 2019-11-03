using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public Node startingNode;

    [HideInInspector]
    public Node currentNode;
    //create an array or list to add or subtract from of bugs 
    public Bug[] bugsEatten;

    public CameraRig rig;

    void Awake()
    {
        //very bad singleton, refresh and look up later
        ins = this;
        ivCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        startingNode.Arrive();
    }
    void Update()
    {
        //If I right click, and im in a prop, then backup to the props location
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if (ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.Arrive();
        } 
    }

}
