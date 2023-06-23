using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowLevelNumber : MonoBehaviour
{
    void Start()
    {
		GetComponent<TextMeshProUGUI> ().text = SceneManager.GetActiveScene ().name;
    }

	void Update() {
		if (!GetComponent<Animation> ().isPlaying)
			gameObject.SetActive (false);
	}
}
