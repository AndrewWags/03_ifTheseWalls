using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;
    public EncounterView view;

    private Queue<string> sentences;

    private void Awake()
    {
        instance = this;

        view.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        view.continueButton.onClick.AddListener(DisplayNextSentence);
    }

   /* void Update()
    {
        //If I right click, and im in a prop, then backup to the props location
        if (Input.GetMouseButtonDown(1) && GameManager.ins.currentNode.GetComponent<Prop>() != null)
        {
            if (view.gameObject.activeInHierarchy)
            {
                view.Close();
                return;
            }
            GameManager.ins.currentNode.GetComponent<Prop>().loc.Arrive();
           
        }
    }
    */

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with: " + dialogue.name);

        view.portrait.sprite = dialogue.portrait;
        view.nameTextField.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        view.textField.text = sentence;

        view.continueButton.gameObject.SetActive(sentences.Count > 0);

        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
