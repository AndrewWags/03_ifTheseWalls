using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;
    public EncounterView view;

    private Queue<string> sentences;

    private bool debugging = false;

    public static bool inEncounter = false;

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

    void HandleTalkButton()
    {
        DisplayNextSentence();
    }

    void HandleEatButton()
    {
        AudioManager.PlayAudio(SfxLibrary.instance.sfx.eat);
        EndEncounter();
    }

    public void StartEncounter(Dialogue dialogue)
    {
        if (debugging) Debug.Log("Starting dialogue with: " + dialogue.name);

        inEncounter = true;

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
            EndEncounter();
            return;
        }

        string sentence = sentences.Dequeue();

        view.textTyper.Type(sentence);        

        view.continueButton.gameObject.SetActive(sentences.Count > 0);

        if (debugging) Debug.Log(sentence);
    }

    public void EndEncounter()
    {
        EndDialogue();

        inEncounter = false;
    }

    void EndDialogue()
    {
        if (debugging) Debug.Log("End of conversation");

        view.fader.FadeOut();
    }
}
