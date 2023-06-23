using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
	public int stage = 1;
	GameObject lastLevelLoaded;
	GameObject purplePortals;
	PurplePortalPlacingController pPPController;
	GameObject winScreen;
	[HideInInspector]
	public int NUM_OF_LEVELS = 13;

    void Awake()
    {
		//PlayerPrefs.SetInt ("CurrentLevel", 1);
		LoadLevel ();
		ShowLevelNumber ();
		purplePortals = GameObject.FindGameObjectWithTag ("Purple Portals");
		pPPController = GameObject.FindObjectOfType<PurplePortalPlacingController> ();
		winScreen = GameObject.FindGameObjectWithTag ("WinScreen");
    }
		
    public void LoadNext()
    {
		if (stage % 4 == 0) {
			stage = 1;
			for (int i = 1; i <= 4; i++) {
				GameObject.Find ("StageShower" + i.ToString ()).GetComponent<Animation> ().Play ("StageReset");
			}
		}
		else
			stage += 1;
		ResetStuff ();
    }

	public void RestartLevel()
	{
		for (int i = 1; i < stage; i++) {
			GameObject.Find ("StageShower" + i.ToString ()).GetComponent<Animation> ().Play ("StageReset");
		}
		stage = 1;
		ResetStuff ();
	}

	public void ResetStuff() {
		ShowLevelNumber ();
		winScreen.SetActive (true);
		if (GameObject.FindObjectOfType<Window_Confetti> () != null)
			Destroy (GameObject.FindObjectOfType<Window_Confetti> ().gameObject);
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("PlayerPieces").Length; i++)
			Destroy (GameObject.FindGameObjectsWithTag ("PlayerPieces") [i]);
		GameObject.FindObjectOfType<Pause> ().paused = false;
		if (FindObjectOfType<PortalCoolDown> ().enabled == true)
			GameObject.FindObjectOfType<PortalCoolDown> ().Reset ();
		purplePortals.SetActive (true);
		pPPController.ResetPortals();
		Destroy (lastLevelLoaded);
		LoadLevel ();
	}

	void ShowLevelNumber() {
		GameObject.Find ("LevelNumber").GetComponent<TextMeshProUGUI> ().text = PlayerPrefs.GetInt ("CurrentLevel", 1).ToString ();
	}

	void LoadLevel() {
		int levelToLoad = PlayerPrefs.GetInt ("CurrentLevel", 1);
		if (levelToLoad > NUM_OF_LEVELS) {
			FindObjectOfType<PortalCoolDown> ().increaseDivider = 5 - Mathf.Ceil ((float)levelToLoad / (float)NUM_OF_LEVELS);
			levelToLoad = levelToLoad % NUM_OF_LEVELS;
			if (levelToLoad == 0)
				levelToLoad = NUM_OF_LEVELS;
		} else
			FindObjectOfType<PortalCoolDown> ().enabled = false;
		string resourcePath = "Prefabs of levels/Level" + levelToLoad.ToString () + "/Stage" + stage.ToString ();
		lastLevelLoaded = Instantiate(Resources.Load <GameObject> (resourcePath), new Vector3(0,0,10), Quaternion.Euler(Vector3.zero), transform);
		if (levelToLoad == 9 & (stage == 2 | stage == 4))
			FindObjectOfType<CameraController> ().xOffset = -10;
		else if (levelToLoad == 13 & stage == 4)
			FindObjectOfType<CameraController> ().xOffset = 0;
		else
			FindObjectOfType<CameraController> ().xOffset = 10;
		if (levelToLoad == 13)
			FindObjectOfType<Camera> ().orthographicSize = 12;
		else
			FindObjectOfType<Camera> ().orthographicSize = 8;
	}
}