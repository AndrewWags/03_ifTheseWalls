using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterView : MonoBehaviour
{
    public Image portrait;
    public Button talkButton;
    public Button eatButton;
    public Button continueButton;
    public Text textField;
    public Text nameTextField;

    public void Activate(Sprite pic)
    {
        gameObject.SetActive(true);
        portrait.sprite = pic;

        GameManager.ins.currentNode.SetReachableNodes(false);
        //if no colider on something, this needs to be amended or it will throw and error looking for one. 
        GameManager.ins.currentNode.col.enabled = false;


    }

    public void Close()
    {
        GameManager.ins.currentNode.SetReachableNodes(true);
        //if no colider on something, this needs to be amended or it will throw and error looking for one. 
        GameManager.ins.currentNode.col.enabled = true;

        gameObject.SetActive(false);
        portrait.sprite = null;
    }
}
