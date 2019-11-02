using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;
    public EncounterView view;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sentences = new Queue<string>();

        view.continueButton.onClick.AddListener(DisplayNextSentence);
    }

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
