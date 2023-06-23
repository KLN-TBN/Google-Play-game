using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
	int score = 0;

    void Update()
    {
		if (GameObject.FindGameObjectWithTag ("Player") != null)
			score = Mathf.RoundToInt (GameObject.FindGameObjectWithTag ("Player").transform.position.x);
		GameObject.Find ("Score").GetComponent<TextMeshProUGUI> ().text = "Score: " + score.ToString();
		if (score > PlayerPrefs.GetInt ("HighScore", 0)) {
			PlayerPrefs.SetInt ("HighScore", score);
			if (GameObject.FindObjectOfType<MyGooglePlayGamesServices>() != null)
				GameObject.FindObjectOfType<MyGooglePlayGamesServices>().PostHighScoreToLeaderboard(score);
		}
		GameObject.Find ("High score").GetComponent<TextMeshProUGUI> ().text = "High Score: " + PlayerPrefs.GetInt ("HighScore", 0).ToString();
	}
}
