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

    public CameraRig rig;

    //very bad singleton, refresh and look up later
    void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
        startingNode.Arrive();
    }
    void Update()
    {
       if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        } 
    }

}
