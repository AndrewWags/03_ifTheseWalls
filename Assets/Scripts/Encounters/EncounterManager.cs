using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;
    public EncounterView view;

    private Queue<string> sentences;

    private bool debugging = false;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        view.continueButton.onClick.AddListener(DisplayNextSentence);
        view.talkButton.onClick.AddListener(HandleTalkButton);
        view.eatButton.onClick.AddListener(HandleEatButton);
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

    void HandleTalkButton()
    {
        DisplayNextSentence();
    }

    void HandleEatButton()
    {
        EndDialogue();
        AudioManager.PlayAudio(SfxLibrary.instance.sfx.eat);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (debugging) Debug.Log("Starting dialogue with: " + dialogue.name);

        view.portrait.sprite = dialogue.portrait;
        view.nameTextField.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        view.fader.FadeIn();

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

        view.textTyper.Type(sentence);        

        view.continueButton.gameObject.SetActive(sentences.Count > 0);

        if (debugging) Debug.Log(sentence);
    }

    void EndDialogue()
    {
        if (debugging) Debug.Log("End of conversation");

        view.fader.FadeOut();
    }
}
