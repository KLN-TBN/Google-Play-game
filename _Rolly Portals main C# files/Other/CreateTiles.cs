using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTiles : MonoBehaviour
{
    
	[SerializeField]
	GameObject tile;
	GameObject tileClone;

	void Start(){
		tileClone = Instantiate (tile, gameObject.transform);
		tileClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width,0);
	}

	float tileX;
	float tileCloneX;
	float playerXVel;

    void Update()
    {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			tileX = tile.GetComponent<RectTransform> ().anchoredPosition.x;
			tileCloneX = tileClone.GetComponent<RectTransform> ().anchoredPosition.x;
			playerXVel = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>().velocity.x;
			tile.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileX - playerXVel/5, 0);
			tileClone.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileCloneX - playerXVel/5, 0);
			if (playerXVel >= 0) {
				if (tileCloneX <= 0 & tileX < tileCloneX)
					tile.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileX + Screen.width, 0);
				//print (tile.GetComponent<RectTransform> ().anchoredPosition.x);
				//print (tileClone.GetComponent<RectTransform> ().anchoredPosition.x);
				if (tileX <= 0 & tileCloneX < tileX)
					tileClone.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileCloneX + Screen.width, 0);
			}
			else {
				if (tileCloneX >= 0 & tileX > tileCloneX)
					tile.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileX - Screen.width, 0);
				if (tileX >= 0 & tileCloneX > tileX)
					tileClone.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tileCloneX - Screen.width, 0);
			}
		}
    }
}
