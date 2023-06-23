using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour {

	PlayerPrefsManager playerPrefsManager;

	// Use this for initialization
	void Start () {			
		playerPrefsManager = GameObject.FindObjectOfType<PlayerPrefsManager> ();
		int value = GenerateValue ();
		GetComponentInChildren<Text> ().text = "+" + value.ToString () + " gems";
		PlayerPrefs.SetInt (playerPrefsManager.gemItemsCountKey, PlayerPrefs.GetInt (playerPrefsManager.gemItemsCountKey, 0) + value);
		PlayerPrefs.SetInt ("Level" + SceneManager.GetActiveScene ().buildIndex.ToString () + "GemChestCollected", 1);
	}

	int GenerateValue() {
		int value = 0;
		int rand = Random.Range (0, 315);
		if (rand < 50)
			value = 10;
		else if (rand < 100)
			value = 20;
		else if (rand < 145)
			value = 30;
		else if (rand < 185)
			value = 40;
		else if (rand < 220)
			value = 50;
		else if (rand < 250)
			value = 60;
		else if (rand < 275)
			value = 70;
		else if (rand < 295)
			value = 80;
		else if (rand < 310)
			value = 90;
		else if (rand < 315)
			value = 100;
		return value;
	}
}
