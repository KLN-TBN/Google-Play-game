using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAppearence : MonoBehaviour {

	struct PlayerPrefkeys {
		public string bowHat;
		public string christmasTreeBall;
		public string fatherChristmasBall;
		public string goldBowHat;
		public string goldChristmasTree;
		public string goldStarHat;
		public string presentBall;
		public string reindeerAntlersHat;
		public string reindeerBall;
		public string santasHat;
		public string starHat;
		public string noobBall;
	};

	PlayerPrefkeys playerPrefKeys;
	GameObject player;
	GameObject pPBall;
	GameObject pPHat;


	// Use this for initialization
	void Start () {
		playerPrefKeys.bowHat = "Bow Hat";
		playerPrefKeys.christmasTreeBall = "Christmas Tree Ball";
		playerPrefKeys.fatherChristmasBall = "Father Christmas Ball";
		playerPrefKeys.goldBowHat = "Gold Bow Hat";
		playerPrefKeys.goldChristmasTree = "Gold Christmas Tree Ball";
		playerPrefKeys.goldStarHat = "Gold Star Hat";
		playerPrefKeys.presentBall = "Present Ball";
		playerPrefKeys.reindeerAntlersHat = "Reindeer Antlers Hat";
		playerPrefKeys.reindeerBall = "Reindeer Ball";
		playerPrefKeys.santasHat = "Santa's Hat";
		playerPrefKeys.starHat = "Star Hat";
		playerPrefKeys.noobBall = "Noob Ball";
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			player.GetComponent<SpriteRenderer> ().sprite = Resources.Load <Sprite> ("Skins/Balls/" + PlayerPrefs.GetString("Player Appearence Ball", "Noob Ball"));
			player.transform.GetChild(0).GetComponent<SpriteRenderer> ().sprite = Resources.Load <Sprite> ("Skins/Hats/" + PlayerPrefs.GetString("Player Appearence Hat"));
		}
		pPBall = GameObject.FindGameObjectWithTag ("PPBall");
		if (pPBall != null) {
			pPBall.GetComponent<RawImage> ().texture = Resources.Load <Texture> ("Skins/Balls/" + PlayerPrefs.GetString("Player Appearence Ball", "Noob Ball"));
		}
		pPHat = GameObject.FindGameObjectWithTag ("PPHat");
		if (pPHat != null) {
			pPHat.GetComponent<RawImage> ().texture = Resources.Load <Texture> ("Skins/Hats/" + PlayerPrefs.GetString("Player Appearence Hat"));
			if (PlayerPrefs.GetString ("Player Appearence Hat", "No Hat") == "No Hat")
				pPHat.GetComponent<RawImage> ().color = new Color32 (1, 1, 1, 0);
			else
				pPHat.GetComponent<RawImage> ().color = Color.white;
		}
	}
}
