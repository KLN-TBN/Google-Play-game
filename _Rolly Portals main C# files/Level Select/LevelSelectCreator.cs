using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectCreator : MonoBehaviour {

	[SerializeField]
	private GameObject diamond;
	[SerializeField]
	private GameObject connector;
	[SerializeField]
	private GameObject moreLevelsComing;

	void Awake () {
		int diamondCount = SceneManager.sceneCountInBuildSettings - 5;
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().sizeDelta.x, Mathf.CeilToInt ((diamondCount + 6) / 3) * 300);
		diamondCount += 1;
		for (int i = 1; i <= diamondCount; i++) {
			int mod = i % 6;
			int yPosDiamond = Mathf.FloorToInt ((i - 1) / 3) * 300 - Mathf.RoundToInt(gameObject.GetComponent<RectTransform> ().sizeDelta.y / 2) + 300;
			int yPosConnector = Mathf.FloorToInt ((i - 1) / 3) * 300 - Mathf.RoundToInt(gameObject.GetComponent<RectTransform> ().sizeDelta.y / 2) + 300;
			int xPosDiamond = -800;
			int xPosConnector = -800;
			int zRotConnector = 0;
			if (mod == 1) {
				xPosDiamond = -400;
				xPosConnector = -200;
			} 
			else if (mod == 2) {
				xPosDiamond = 0;
				xPosConnector = 200;
			} 
			else if (mod == 3) {
				xPosDiamond = 400;
				xPosConnector = 400;
				zRotConnector = 90;
				yPosConnector += 150;
			}
			else if (mod == 4){
				xPosDiamond = 400;
				xPosConnector = 200;
			}
			else if (mod == 5){
				xPosDiamond = 0;
				xPosConnector = -200;
			}
			else if (mod == 0){
				xPosDiamond = -400;
				xPosConnector = -400;
				zRotConnector = 90;
				yPosConnector += 150;
			}

			if (i != diamondCount){
				GameObject connectorGO = Instantiate (connector, transform);
				connectorGO.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (xPosConnector, yPosConnector);
				connectorGO.GetComponent<RectTransform> ().rotation = Quaternion.Euler(new Vector3(0,0,zRotConnector));
			}
			GameObject diamondGO;
			if (i == diamondCount & PlayerPrefs.GetInt ("Level" + (diamondCount - 1) + "Complete", 0) == 1) {
				diamondGO = Instantiate (moreLevelsComing, transform);
				diamondGO.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (xPosDiamond, yPosDiamond);
			}
			else if (i != diamondCount){
				diamondGO = Instantiate (diamond, transform);
				diamondGO.GetComponentInChildren<TextMeshProUGUI> ().text = i.ToString ();
				diamondGO.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (xPosDiamond, yPosDiamond);
			}
		}
	}
}
