using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lock : MonoBehaviour {

	void Start () {
		int level = int.Parse (transform.parent.GetComponentInChildren<TextMeshProUGUI> ().text);
		if (PlayerPrefs.GetInt ("Level" + (level - 1) + "Complete", 0) == 1 | level == 1) {
			gameObject.SetActive (false);
		}
	}
}
