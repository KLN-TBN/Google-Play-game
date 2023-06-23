using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SkipLevelButton : MonoBehaviour
{

	GameObject skipLevelButton;

    void Start()
    {
		skipLevelButton = GameObject.FindGameObjectWithTag ("SkipLevelButton");
		if (SceneManager.GetActiveScene ().buildIndex == SceneManager.sceneCountInBuildSettings - 4)
			skipLevelButton.SetActive (false);
		skipLevelButton.transform.parent.gameObject.SetActive (false);
    }

	public void SkipLevel() {
		GameObject.FindObjectOfType<MySceneManager>().NextScene ();
		AnalyticsEvent.LevelComplete (SceneManager.GetActiveScene ().buildIndex);
		PlayerPrefs.SetInt ("Level" + SceneManager.GetActiveScene ().buildIndex + "Complete", 1);
	}
}