using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{

	GameObject level;
	Vector2 finishLinePos;
	Vector2 ballPosition;
	float xDisplacement;
	float yDisplacement;
	float seventhLevelXPos;
	int minLevelN = 2;
	int maxLevelN = 5;

    void Start()
    {
		Vector2 actualBallPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

		level = Resources.Load <GameObject> ("Prefabs of levels/Level" + GenerateRandomNumber().ToString());
		level = Instantiate (level);
		ballPosition = Vector2.zero;
		for (int i = 0; i < level.transform.childCount; i++) {
			if (level.transform.GetChild (i).gameObject.tag == "Player") {
				ballPosition = level.transform.GetChild (i).position;
				Destroy (level.transform.GetChild (i).gameObject);
			}
		}
		xDisplacement = actualBallPosition.x - ballPosition.x;
		yDisplacement = actualBallPosition.y - ballPosition.y;
		level.transform.position = new Vector3 (level.transform.position.x + xDisplacement, level.transform.position.y + yDisplacement, 10);

		CreateTenLevels ();
    }

	void FixedUpdate() {
		foreach (GameObject saw in GameObject.FindGameObjectsWithTag("Saw")) {
			saw.transform.parent.rotation = Quaternion.Euler (Vector3.zero);
		}
		if (PlayerPrefs.GetInt ("HighScore", 0) >= 550)
			maxLevelN = Mathf.RoundToInt(PlayerPrefs.GetInt ("HighScore", 0) / 100);
		if (maxLevelN > 21)
			maxLevelN = 21;
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			if (GameObject.FindGameObjectWithTag ("Player").transform.position.x > seventhLevelXPos)
				CreateTenLevels ();
		}
	}

	int GenerateRandomNumber(){
		int fiftyFifty = Random.Range (1, 3);
		if (maxLevelN >= 18) {
			if (fiftyFifty == 1)
				return Random.Range (minLevelN, 18);
			else
				return Random.Range (20, maxLevelN + 1);
		} else {
			return Random.Range (minLevelN, maxLevelN + 1);
		}
	}

	void CreateTenLevels(){
		for (int x = 0; x < 10; x ++){
			finishLinePos = Vector2.zero;
			for (int i = 0; i < level.transform.childCount; i++) {
				if (level.transform.GetChild (i).GetComponent<FinishLine>() != null) {
					finishLinePos = level.transform.GetChild (i).position;
					Destroy (level.transform.GetChild (i).gameObject);
				}
			}
			level = Resources.Load <GameObject> ("Prefabs of levels/Level" + GenerateRandomNumber().ToString());
			level = Instantiate (level);
			for (int i = 0; i < level.transform.childCount; i++) {
				if (level.transform.GetChild (i).gameObject.tag == "Player") {
					ballPosition = level.transform.GetChild (i).position;
					Destroy (level.transform.GetChild (i).gameObject);
				}
			}
			xDisplacement = finishLinePos.x - ballPosition.x;
			yDisplacement = finishLinePos.y - ballPosition.y;
			level.transform.position = new Vector3 (level.transform.position.x + xDisplacement - 1, level.transform.position.y + yDisplacement - 7, 10);
			if (x == 7)
				seventhLevelXPos = level.transform.position.x;
		}
	}
}
