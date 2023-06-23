using System;
using UnityEngine;
using TMPro;

public class PortalRefiller : MonoBehaviour {

	PlayerPrefsManager playerPrefsManager;
	int lastTimePortalCountUpdated;
	int secondsForPortalRefill;
	[HideInInspector]
	public int maxPortalCount;
	// Use this for initialization
	void Start () {
		maxPortalCount = RemoteSettings.GetInt ("MaxPortals", 1000);
		secondsForPortalRefill = RemoteSettings.GetInt("SecondsForPortalRefill", 900);
		playerPrefsManager = GameObject.FindObjectOfType<PlayerPrefsManager> ();
		if (GameObject.FindGameObjectWithTag ("PortalRefillInfo") != null)
			GameObject.FindGameObjectWithTag ("PortalRefillInfo").GetComponent<TextMeshProUGUI> ().text = "Seconds for portal refill: " + secondsForPortalRefill.ToString() + " , Maximum portals: " + maxPortalCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) > maxPortalCount)
			PlayerPrefs.SetInt (playerPrefsManager.portalItemsCountKey, maxPortalCount);
		DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		int unixEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
		lastTimePortalCountUpdated = PlayerPrefs.GetInt ("LastTimePortalCountUpdated", 0);
		if (lastTimePortalCountUpdated == 0)
			PlayerPrefs.SetInt ("LastTimePortalCountUpdated", unixEpochTime);
		if (PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) < maxPortalCount) {
			int difference = unixEpochTime - lastTimePortalCountUpdated;
			int secondsLeft = secondsForPortalRefill - difference;
			string timeLeft = ToDoubleDigitString(Mathf.FloorToInt (secondsLeft / 60)) + ":" + ToDoubleDigitString(secondsLeft % 60);
			if (GameObject.FindGameObjectWithTag ("PortalRefillTime") != null)
				GameObject.FindGameObjectWithTag ("PortalRefillTime").GetComponent<TextMeshProUGUI> ().text = timeLeft;
			int extraPortals = Mathf.FloorToInt (difference / secondsForPortalRefill) * 40;
			if (extraPortals > 0) {
				int newValue = PlayerPrefs.GetInt (playerPrefsManager.portalItemsCountKey, 0) + extraPortals;
				PlayerPrefs.SetInt ("LastTimePortalCountUpdated", unixEpochTime);
				if (newValue <= maxPortalCount)
					PlayerPrefs.SetInt (playerPrefsManager.portalItemsCountKey, newValue);
				else
					PlayerPrefs.SetInt (playerPrefsManager.portalItemsCountKey, maxPortalCount);
			}
		} else {
			if (GameObject.FindGameObjectWithTag ("PortalRefillTime") != null)
				GameObject.FindGameObjectWithTag ("PortalRefillTime").GetComponent<TextMeshProUGUI> ().text = "00:00";
		}
	}

	string ToDoubleDigitString(int value) { 
		if (value.ToString ().Length == 1)
			return "0" + value.ToString ();
		return value.ToString ();
	}
}
