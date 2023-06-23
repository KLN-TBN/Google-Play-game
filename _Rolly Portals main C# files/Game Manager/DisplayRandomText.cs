using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRandomText : MonoBehaviour {

	[SerializeField]
	private string[] phrases;

	void Start () {
		int randIndex = Random.Range (0, phrases.Length);
		gameObject.GetComponent<TextMeshProUGUI>().text = phrases[randIndex];
	}

}
