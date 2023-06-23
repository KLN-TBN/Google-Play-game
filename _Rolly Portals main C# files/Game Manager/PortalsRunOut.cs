using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortalsRunOut : MonoBehaviour {

	private TextMeshProUGUI purplePortalsLeftCount;
	private PurplePortalPlacingController purplePortalPlacingController;
	[HideInInspector]
	public bool zeroPortalsLeft = false;
	GameObject ranOutScreen;
	Vector2 velocityBeforePausing;
	float angularVelocityBeforePausing;
	GameObject player;
	GameObject pauseButton;
	TextMeshProUGUI timer;
	GameObject resumeButton;

	void Start () {
		if (GameObject.FindObjectOfType<Pause> () != null)
			timer = GameObject.FindObjectOfType<Pause> ().timer;
		if (GameObject.FindGameObjectWithTag ("PortalItems") != null)
			purplePortalsLeftCount = GameObject.FindGameObjectWithTag ("PortalItems").GetComponentInChildren<TextMeshProUGUI> ();
		purplePortalPlacingController = GameObject.FindObjectOfType<PurplePortalPlacingController> ();
		ranOutScreen = GameObject.FindGameObjectWithTag ("RanOutOfPortalsScreen");
		if (ranOutScreen != null)
			ranOutScreen.SetActive (false);
		if (GameObject.FindGameObjectWithTag ("PauseButton") != null)
			pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
	}

	void Update() 
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null)
			player = GameObject.FindGameObjectWithTag ("Player");
		if (ranOutScreen != null & PlayerPrefs.GetInt(GameObject.FindObjectOfType<PlayerPrefsManager>().portalItemsCountKey, RemoteSettings.GetInt("MaxPortals", 1000)) == 0 & ! zeroPortalsLeft) {
			if (GameObject.FindObjectOfType<Pause> () != null)
				GameObject.FindObjectOfType<Pause> ().paused = true;
			ranOutScreen.SetActive (true);
			GameObject.FindObjectOfType<PlayerPrefsManager> ().buyPortalsButton = GameObject.FindGameObjectWithTag ("BuyPortalsButton");
			/*resumeButton = GameObject.FindGameObjectWithTag ("ResumeButton");
			GameObject.FindGameObjectWithTag ("ResumeButton").SetActive(false);*/
			velocityBeforePausing = player.GetComponent<Rigidbody2D> ().velocity;
			angularVelocityBeforePausing = player.GetComponent<Rigidbody2D> ().angularVelocity;
			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			if (GameObject.FindGameObjectWithTag ("Saw") != null) {
				foreach (GameObject saw in GameObject.FindGameObjectsWithTag("Saw"))
					saw.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			}
			zeroPortalsLeft = true;
		}
		/*if (PlayerPrefs.GetInt(GameObject.FindObjectOfType<PlayerPrefsManager>().portalItemsCountKey, RemoteSettings.GetInt("MaxPortals", 1000)) > 0 & resumeButton != null)
			resumeButton.SetActive(true);*/
	}

	IEnumerator Timer(){
		timer.gameObject.SetActive (true);
		timer.text = "3";
		timer.GetComponent<Animation> ().Play ();
		yield return new WaitForSeconds (1f);
		timer.text = "2";
		yield return new WaitForSeconds (1f);
		timer.text = "1";
		yield return new WaitForSeconds (1f);
		ResumeAfterTimer ();
	}

	public void Resume() {
		ranOutScreen.SetActive (false);
		StartCoroutine (Timer ());
	}

	void ResumeAfterTimer (){
		player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		if (GameObject.FindGameObjectWithTag ("Saw") != null) {
			foreach (GameObject saw in GameObject.FindGameObjectsWithTag("Saw"))
				saw.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		}
		player.GetComponent<Rigidbody2D> ().velocity = velocityBeforePausing;
		player.GetComponent<Rigidbody2D> ().angularVelocity = angularVelocityBeforePausing;
		zeroPortalsLeft = false;
		if (GameObject.FindObjectOfType<PurplePortalPlacingController> () != null)
			purplePortalPlacingController.enabled = true;
		if (GameObject.FindObjectOfType<Pause> () != null)
			GameObject.FindObjectOfType<Pause> ().paused = false;
	}
}