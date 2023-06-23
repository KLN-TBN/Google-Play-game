using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	private PlayerPrefsManager playerPrefsManager;
	[SerializeField]
	private Text portalRefillPrice;
	private int maxLives = 20;

	void Start () {
		playerPrefsManager = GameObject.FindObjectOfType<PlayerPrefsManager> ();
	}

	void Update() {
		portalRefillPrice.text = (40 * (maxLives - PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0))).ToString();
	}

	public void BuyOneLife(){
		if (PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) < maxLives)
			BuyItem (playerPrefsManager.portalItemsCountKey, 1, 50);
		else {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.FailSoundClip ();
			}
			GameObject.FindGameObjectWithTag ("LifeItems").GetComponentInChildren<Animation> ().Play ();
		}
	}

	public void Buy5Lives(){
		if (PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) < maxLives-4)
			BuyItem (playerPrefsManager.portalItemsCountKey, 5, 220);
		else {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.FailSoundClip ();
			}
			GameObject.FindGameObjectWithTag ("LifeItems").GetComponentInChildren<Animation> ().Play ();
		}
	}

	public void RefillLives(){
		if (PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) < maxLives-5) {
			int prize = maxLives - PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0);
			int price = 40 * prize;
			BuyItem (playerPrefsManager.portalItemsCountKey, prize, price);
		}
		else {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.FailSoundClip ();
			}
			GameObject.FindGameObjectWithTag ("LifeItems").GetComponentInChildren<Animation> ().Play ();
		}
	}

	private void BuyItem(string key, int prize, int price){
		if (PlayerPrefs.GetInt (playerPrefsManager.gemItemsCountKey, 0) >= price & price > 0) {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.RevertAudioClip();
			}
			PlayerPrefs.SetInt (playerPrefsManager.gemItemsCountKey, PlayerPrefs.GetInt (playerPrefsManager.gemItemsCountKey, 0) - price);
			PlayerPrefs.SetInt (key, PlayerPrefs.GetInt (key, 0) + prize);
		}
		else {
			ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
			foreach (ButtonSounds button in buttons) {
				button.FailSoundClip ();
			}
			GameObject.FindGameObjectWithTag ("GemItems").GetComponentInChildren<Animation> ().Play ();
		}	
	}
		
	public void BuyGems(int amount) {
		ButtonSounds[] buttons = GameObject.FindObjectsOfType<ButtonSounds> ();
		foreach (ButtonSounds button in buttons) {
			button.RevertAudioClip();
		}
		string key = playerPrefsManager.gemItemsCountKey;
		int newAmount = PlayerPrefs.GetInt (key, 0) + amount;
		PlayerPrefs.SetInt (key, newAmount);
	}
}
