using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Analytics;

public class MySceneManager : MonoBehaviour {

	void Start() {
		AnalyticsEvent.LevelStart (SceneManager.GetActiveScene ().buildIndex);
	}

	public void StartLevel() {
		if (PlayerPrefs.GetInt (GetComponent<PlayerPrefsManager> ().portalItemsCountKey, 0) != 0) {
			int index = int.Parse (gameObject.GetComponentInChildren<TextMeshProUGUI> ().text);
			if (gameObject.GetComponentInChildren<Lock> () == null) {
				ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
				foreach (ButtonSounds button in buttons) {
					button.RevertAudioClip();
				}
				StartCoroutine (DelaySceneLoad (index));
			}
			else {
				ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
				foreach (ButtonSounds button in buttons) {
					button.FailSoundClip ();
				}
			}
		} else {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.FailSoundClip ();
			}
			GameObject.FindGameObjectWithTag ("PortalItems").GetComponentInChildren<Animation> ().Play ();
		}
	}

	public void PlayFromHighestLevel() {
		StartCoroutine(DelaySceneLoad(1));
	}

	public void NextScene() {
		int index = SceneManager.GetActiveScene ().buildIndex + 1;
		StartCoroutine(DelaySceneLoad(index));
	}

	public void RestartScene() {
		int index = SceneManager.GetActiveScene ().buildIndex;
		StartCoroutine(DelaySceneLoad(index));
	}

	public void MainMenu() {
		ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
		foreach (ButtonSounds button in buttons) {
			button.RevertAudioClip();
		}
		StartCoroutine(DelaySceneLoad(0));
	}

	public void OpenInfinite() {
		int index = SceneManager.sceneCountInBuildSettings - 4;
		StartCoroutine(DelaySceneLoad(index));
	}

	public void OpenLevelSelect() {
		int index = SceneManager.sceneCountInBuildSettings - 3;
		StartCoroutine(DelaySceneLoad(index));
	}

	public void OpenProfile() {
		int index = SceneManager.sceneCountInBuildSettings - 2;
		StartCoroutine(DelaySceneLoad(index));
	}

	public void OpenInstagram() {
		Application.OpenURL ("https://www.instagram.com/bolhetti/");
	}

	public void OpenPlayStore() {
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.Bolhetti.RollyPortals");
	}

	public void OpenPrivacyPolicy() {
		Application.OpenURL ("https://photos.app.goo.gl/wqvSw726KkLjayb2A");
	}

	IEnumerator DelaySceneLoad(int index) {
		yield return new WaitForSeconds (0.3f);
		LoadingScreenManager.LoadScene (index);
	}
}