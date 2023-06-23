using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerPrefsManager : MonoBehaviour {

	[HideInInspector]
	public string gemItemsCountKey = "GemItemsCount";
	[HideInInspector]
	public string portalItemsCountKey = "PortalItemsCount";
	[HideInInspector]
	public int maxPortalCount;
	[HideInInspector]
	public GameObject buyPortalsButton;

	private void Start() {
		maxPortalCount = RemoteSettings.GetInt ("MaxPortals", 1000);
		//PlayerPrefs.SetInt (portalItemsCountKey, 10);
		//PlayerPrefs.SetInt ("Level" + 31 + "Complete", 0);
	}

	void Update() {
		if (GameObject.FindGameObjectWithTag("RefillPortalsMainMenu") != null){
			if (PlayerPrefs.GetInt (portalItemsCountKey, maxPortalCount) == maxPortalCount)
				GameObject.FindGameObjectWithTag ("RefillPortalsMainMenu").SetActive (false);
		}
		if (GameObject.FindGameObjectWithTag ("GemItems") != null)
			DisplayItemsCount (GameObject.FindGameObjectWithTag ("GemItems"), gemItemsCountKey);
		if (GameObject.FindGameObjectWithTag ("PortalItems") != null)
			DisplayItemsCount (GameObject.FindGameObjectWithTag ("PortalItems"), portalItemsCountKey);
	}

	public void UsePortal() {
		if (PlayerPrefs.GetInt (portalItemsCountKey, maxPortalCount) > 0) {
			int newValue = PlayerPrefs.GetInt (portalItemsCountKey, maxPortalCount) - 1;
			PlayerPrefs.SetInt(portalItemsCountKey, newValue);
		}
	}

	private void DisplayItemsCount(GameObject items, string key) {
		if (key == portalItemsCountKey)
			items.GetComponentInChildren<TextMeshProUGUI> ().text = PlayerPrefs.GetInt (key, maxPortalCount).ToString();
		else
			items.GetComponentInChildren<TextMeshProUGUI> ().text = PlayerPrefs.GetInt (key, 0).ToString();
	}

	public void RefillPortals() {
		PlayerPrefs.SetInt (portalItemsCountKey, maxPortalCount);
		StartCoroutine (DelayButtonDeactivate ());
	}

	IEnumerator DelayButtonDeactivate() {
		yield return new WaitForSeconds (0.1f);
		buyPortalsButton.SetActive(false);
	}
}
