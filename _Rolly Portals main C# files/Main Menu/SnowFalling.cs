using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFalling : MonoBehaviour {

	[SerializeField]
	float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float y = GetComponent<RectTransform> ().localPosition.y;
		GetComponent<RectTransform> ().localPosition = new Vector3 (0, y - speed);
		float yMax = GameObject.Find ("Canvas Overlay").GetComponent<RectTransform> ().sizeDelta.y;
		if (y < (yMax + 100) * -1)
			GetComponent<RectTransform> ().localPosition = new Vector3 (0, yMax);
	}
}
