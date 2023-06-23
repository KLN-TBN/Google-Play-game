using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class News : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMeshProUGUI> ().text = RemoteSettings.GetString ("news", "News is displayed here (connect to wifi)");
	}
}
