using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour {

	GameObject purplePortals;
	GameObject player;
	[HideInInspector]
	public bool paused = false;
	Vector2 velocityBeforePausing;
	float angularVelocityBeforePausing;
	float cameraSizeBeforePausing;
	[HideInInspector]
	public TextMeshProUGUI timer;
	GameObject pauseButton;

	// Use this for initialization
	void Awake () {
		timer = GameObject.FindGameObjectWithTag ("3SecondTimer").GetComponent<TextMeshProUGUI>();
		timer.gameObject.SetActive (false);
		purplePortals = GameObject.FindGameObjectWithTag ("Purple Portals");
		player = GameObject.FindGameObjectWithTag ("Player");
		if (GameObject.FindGameObjectWithTag ("PauseButton") != null) {
			pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
			pauseButton.GetComponent<Button> ().onClick.AddListener (() => PauseMenu ());
		}
	}

	void PauseMenu() {
		cameraSizeBeforePausing = Camera.main.orthographicSize;
		purplePortals.GetComponent<PurplePortalPlacingController>().enabled = false;
		velocityBeforePausing = player.GetComponent<Rigidbody2D> ().velocity;
		angularVelocityBeforePausing = player.GetComponent<Rigidbody2D> ().angularVelocity;
		player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		if (GameObject.FindGameObjectWithTag ("Saw") != null) {
			foreach (GameObject saw in GameObject.FindGameObjectsWithTag("Saw"))
				saw.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		}
		pauseButton.GetComponent<Image> ().color = new Color32 (31, 0, 255, 0);
		paused = true;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ().enabled = false;
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
		PlayAfterTimer ();
	}

	public void Play() {
		StartCoroutine (Timer ());
	}

	void PlayAfterTimer(){
		Camera.main.orthographicSize = cameraSizeBeforePausing;
		purplePortals.GetComponent<PurplePortalPlacingController>().enabled = true;
		player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		if (GameObject.FindGameObjectWithTag ("Saw") != null) {
			foreach (GameObject saw in GameObject.FindGameObjectsWithTag("Saw"))
				saw.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		}
		pauseButton.GetComponent<Image> ().color = new Color32 (31, 0, 255, 255);
		paused = false;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ().enabled = true;
		player.GetComponent<Rigidbody2D> ().velocity = velocityBeforePausing;
		player.GetComponent<Rigidbody2D> ().angularVelocity = angularVelocityBeforePausing;
	}

	Vector3 touchStart;
	public float zoomOutMin = 8;
	public float zoomOutMax = 50;

	// Update is called once per frame
	void Update () {
		if (paused) {
			if (Input.GetMouseButtonDown (0)) {
				touchStart = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			if (Input.touchCount == 2) {
				Touch touchZero = Input.GetTouch (0);
				Touch touchOne = Input.GetTouch (1);

				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

				float difference = currentMagnitude - prevMagnitude;

				zoom (difference * 0.01f);
			} else if (Input.GetMouseButton (0)) {
				Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Camera.main.transform.position += direction;
			}
			zoom (Input.GetAxis ("Mouse ScrollWheel"));
		}
	}

	void zoom(float increment){
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
	}

}
