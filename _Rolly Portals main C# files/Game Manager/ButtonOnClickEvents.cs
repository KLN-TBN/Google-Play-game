using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClickEvents : MonoBehaviour {

	MySceneManager mySceneManager;

	void Start () {
		mySceneManager = GameObject.FindObjectOfType<MySceneManager> ();
		Button[] buttonObjects = Resources.FindObjectsOfTypeAll<Button> ();
		for (int i = 0; i < buttonObjects.Length; i++) {
			if (buttonObjects[i].tag == "HomeButton")
				buttonObjects [i].onClick.AddListener (() => mySceneManager.MainMenu ());
			else if (buttonObjects[i].tag == "ReplayButton")
				buttonObjects [i].onClick.AddListener (() => GameObject.FindObjectOfType<LevelLoader> ().RestartLevel());
			else if (buttonObjects[i].tag == "ReviveButton")
				buttonObjects [i].onClick.AddListener (() => GameObject.FindObjectOfType<LevelLoader> ().ResetStuff());
			else if (buttonObjects[i].tag == "NextLevelButton")
				buttonObjects [i].onClick.AddListener (() => GameObject.FindObjectOfType<LevelLoader> ().LoadNext());
			else if (buttonObjects[i].tag == "InstagramButton")
				buttonObjects [i].onClick.AddListener (() => mySceneManager.OpenInstagram ());
			else if (buttonObjects[i].tag == "PlayStoreButton")
				buttonObjects [i].onClick.AddListener (() => mySceneManager.OpenPlayStore ());
			else if (buttonObjects[i].tag == "ResumeButton")
				buttonObjects [i].onClick.AddListener (() => GameObject.FindObjectOfType<PortalsRunOut>().Resume());
		}
	}
}
