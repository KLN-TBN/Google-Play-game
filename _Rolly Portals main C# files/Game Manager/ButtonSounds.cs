using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour {

	private AudioClip normalSound;
	private AudioClip failSound;

	private Button button {get { return GetComponent<Button> (); } }
	private AudioSource source {get { return GetComponent<AudioSource> (); } }

	// Use this for initialization
	void Start () {
		normalSound = Resources.Load<AudioClip>("ClickSound");
		failSound = Resources.Load<AudioClip>("FailSound");;
		source.clip = normalSound;
		source.playOnAwake = false;

		Button[] buttonObjects = Resources.FindObjectsOfTypeAll<Button> ();
		for (int i = 0; i < buttonObjects.Length; i++) {
			buttonObjects [i].onClick.AddListener (() => PlaySound ());
		}
	}

	void PlaySound () {
		source.PlayOneShot (source.clip);
	}

	void PlayFailSound () {
		source.PlayOneShot (failSound);
	}

	public void FailSoundClip(){
		source.clip = failSound;
	}

	public void ToggleFailSoundClip(){
		Toggle[] toggleObjects = Resources.FindObjectsOfTypeAll<Toggle> ();
		for (int i = 0; i < toggleObjects.Length; i++) {
			toggleObjects [i].onValueChanged.AddListener (delegate {PlayFailSound ();} );
		}
	}

	public void ToggleSoundClip(){
		Toggle[] toggleObjects = Resources.FindObjectsOfTypeAll<Toggle> ();
		for (int i = 0; i < toggleObjects.Length; i++) {
			toggleObjects [i].onValueChanged.AddListener (delegate {PlaySound ();} );
		}
	}

	public void RevertAudioClip(){
		source.clip = normalSound;
	}
}
