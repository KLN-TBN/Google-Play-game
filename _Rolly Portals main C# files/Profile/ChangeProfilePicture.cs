using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProfilePicture : MonoBehaviour {

	PlayerAppearence playerAppearence;
	RawImage ball;
	RawImage hat;

	// Use this for initialization
	void Start () {
		playerAppearence = GameObject.FindObjectOfType<PlayerAppearence> ();
		ball = GameObject.FindGameObjectWithTag("PPBall").GetComponent<RawImage>();
		hat = GameObject.FindGameObjectWithTag("PPHat").GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeBall() {
		PlayerPrefs.SetString("Player Appearence Ball", gameObject.name);
	}

	public void ChangeHat() {
		PlayerPrefs.SetString("Player Appearence Hat", gameObject.name);
	}
}
