using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Text))]
public class Typer : MonoBehaviour {

	public string message = "Replace";
	public Text text;
	public float startDelay = 2f;
	public float typeDelay = 0.0f;
	public AudioClip typeSound;

    IEnumerator typingSequence = null;

    private bool debugging = false;

	void Awake() {
		if(text == null) text = GetComponent<Text>();
	}
	
    public void Type(string newMessage)
    {
        if (typingSequence != null) StopCoroutine(typingSequence);
        typingSequence = TypeInSequence();

        message = newMessage;

        StartCoroutine(typingSequence);
    }

	private IEnumerator TypeInSequence() {
		yield return new WaitForSeconds(startDelay);

        if (debugging) Debug.Log("Typing message: " + message);

		for(int i = 0; i < message.Length + 1; i++) {
			text.text = message.Substring(0, i);
			GetComponent<AudioSource>().PlayOneShot(typeSound);
			yield return new WaitForSeconds(typeDelay);
		}
	}
	
	private IEnumerator TypeOff() {
		yield return new WaitForSeconds(startDelay);
		
		for(int i = 0; i >= 0; i--) {
			text.text = message.Substring(0, i);
			yield return new WaitForSeconds(typeDelay);
		}
	}	

}

