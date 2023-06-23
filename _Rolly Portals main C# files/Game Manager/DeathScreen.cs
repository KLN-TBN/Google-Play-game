using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour {

	GameObject deathScreen;

	void Start() {
		if (GameObject.FindGameObjectWithTag ("DeathScreen") != null) {
			deathScreen = GameObject.FindGameObjectWithTag ("DeathScreen");
			deathScreen.SetActive (false);
		}
	}

	public void Activate(string deathReasonText){
		deathScreen.SetActive (true);
		if (GameObject.FindGameObjectWithTag ("Purple Portals") != null)
			GameObject.FindGameObjectWithTag ("Purple Portals").SetActive (false);
		deathScreen.GetComponentInChildren<TextMeshProUGUI>().text = deathReasonText;
		if (GameObject.FindObjectOfType<Pause> () != null)
			GameObject.FindObjectOfType<Pause> ().paused = true;
	}
}