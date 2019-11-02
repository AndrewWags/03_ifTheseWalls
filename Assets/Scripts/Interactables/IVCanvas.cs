using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour
{
    public Image imageHolder;

    public void Activate(Sprite pic)
    {
        GameManager.ins.currentNode.SetReachableNodes(false);
        //if no colider on something, this needs to be amended or it will throw and error looking for one. 
        GameManager.ins.currentNode.col.enabled = false;

        gameObject.SetActive(true);
        imageHolder.sprite = pic;
    }

    public void Close()
    {
        GameManager.ins.currentNode.SetReachableNodes(true);
        //if no colider on something, this needs to be amended or it will throw and error looking for one. 
        GameManager.ins.currentNode.col.enabled = true;

        gameObject.SetActive(false);
        imageHolder.sprite = null;
    }
}
