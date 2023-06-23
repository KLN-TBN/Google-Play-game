using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using TMPro;

public class FinishLine : MonoBehaviour {

    private GameObject winScreen;

	void Start() {
		if (GameObject.FindGameObjectWithTag ("WinScreen") != null) {
			winScreen = GameObject.FindGameObjectWithTag ("WinScreen");
			winScreen.SetActive (false);
		}
		//transform.position = new Vector2 (transform.position.x, transform.position.y - 1);
	}

	void Update() {
		if (GameObject.FindGameObjectWithTag ("Player") != null)
			transform.position = new Vector3 (transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag ("Player").transform.position.z);
		if (winScreen == null) {
			if (GameObject.FindGameObjectWithTag ("WinScreen") != null) {
				winScreen = GameObject.FindGameObjectWithTag ("WinScreen");
				winScreen.SetActive (false);
			}
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag ("Player") & winScreen != null & collision.isTrigger) {
			winScreen.SetActive(true);
			AnalyticsEvent.LevelComplete (SceneManager.GetActiveScene ().buildIndex);
			collision.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			//Time.timeScale = 0.3f;
			PlayerPrefs.SetInt ("Level" + SceneManager.GetActiveScene ().buildIndex + "Complete", 1);
			if (GameObject.FindGameObjectWithTag ("Purple Portals") != null)
				GameObject.FindGameObjectWithTag ("Purple Portals").SetActive (false);
			if (GameObject.FindObjectOfType<Pause> () != null)
				GameObject.FindObjectOfType<Pause> ().paused = true;
			int stage = FindObjectOfType<LevelLoader> ().stage;
			GameObject.Find ("StageShower" + stage.ToString ()).GetComponent<Animation> ().Play ("StagePassed");
			if (stage == 4) {
				if (PlayerPrefs.GetInt ("CurrentLevel", 1) % FindObjectOfType<LevelLoader> ().NUM_OF_LEVELS == 0)
					winScreen.GetComponentInChildren<TextMeshProUGUI> ().text = "wave " + (PlayerPrefs.GetInt ("CurrentLevel", 1) / FindObjectOfType<LevelLoader> ().NUM_OF_LEVELS).ToString () + " complete";
				else
					winScreen.GetComponentInChildren<TextMeshProUGUI> ().text = "level " + PlayerPrefs.GetInt ("CurrentLevel", 1).ToString () + " finished";
				PlayerPrefs.SetInt ("CurrentLevel", PlayerPrefs.GetInt ("CurrentLevel", 1) + 1);
			} else
				winScreen.GetComponentInChildren<TextMeshProUGUI> ().text = "stage " + stage.ToString () + " passed";
		}
    }
}