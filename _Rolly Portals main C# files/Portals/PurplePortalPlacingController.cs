using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePortalPlacingController : MonoBehaviour {

    public int portalsPlaced = 0;
	bool bothTouchesEnded = true;

    // Update is called once per frame
    void Update () {
		/*
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.touches[i].phase == TouchPhase.Moved) {
				Vector3 direction = Camera.main.ScreenToWorldPoint (new Vector3(Input.touches[i].deltaPosition.x, Input.touches[i].deltaPosition.y, 0));
				Camera.main.transform.position += direction;
			}
			else if (Input.touches[i].phase == TouchPhase.Stationary  & !GameObject.FindObjectOfType<PortalCoolDown> ().reachedMax) {
				Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
				transform.GetChild(portalsPlaced % 2).gameObject.SetActive(false);
				transform.GetChild(portalsPlaced % 2).gameObject.SetActive(true);
				transform.GetChild(portalsPlaced % 2).position = newPos;
				portalsPlaced += 1;
				GameObject.FindObjectOfType<PlayerPrefsManager> ().UsePortal ();
				GameObject.FindObjectOfType<PortalCoolDown> ().FillIncrease ();
			}
		}*/

		if (Input.touchCount > 1 & bothTouchesEnded & !GameObject.FindObjectOfType<PortalsRunOut> ().zeroPortalsLeft & !GameObject.FindObjectOfType<PortalCoolDown> ().reachedMax) {
			bothTouchesEnded = false;
			Vector2 newPos1 = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(0).position = newPos1;
			Vector2 newPos2 = Camera.main.ScreenToWorldPoint(Input.touches[1].position);
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(true);
			transform.GetChild(1).position = newPos2;
			portalsPlaced += 2;
			GameObject.FindObjectOfType<PlayerPrefsManager> ().UsePortal ();
			if (FindObjectOfType<PortalCoolDown> ().enabled)
				GameObject.FindObjectOfType<PortalCoolDown> ().FillIncrease ();
			GameObject.FindObjectOfType<PlayerPrefsManager> ().UsePortal ();
			if (FindObjectOfType<PortalCoolDown> ().enabled)
				GameObject.FindObjectOfType<PortalCoolDown> ().FillIncrease ();
		}
		else if (Input.GetMouseButtonDown(0)  & !GameObject.FindObjectOfType<PortalsRunOut> ().zeroPortalsLeft & !GameObject.FindObjectOfType<PortalCoolDown> ().reachedMax) //& (Input.mousePosition.x < 607 | Input.mousePosition.x > 663 | Input.mousePosition.y < 631))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.GetChild(portalsPlaced % 2).gameObject.SetActive(false);
			transform.GetChild(portalsPlaced % 2).gameObject.SetActive(true);
			transform.GetChild(portalsPlaced % 2).position = newPos;
            portalsPlaced += 1;
			GameObject.FindObjectOfType<PlayerPrefsManager> ().UsePortal ();
			if (FindObjectOfType<PortalCoolDown> ().enabled)
				GameObject.FindObjectOfType<PortalCoolDown> ().FillIncrease ();
		}
		if (Input.touches.Length > 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended & Input.GetTouch (1).phase == TouchPhase.Ended)
				bothTouchesEnded = true;
		}
    }

	public void ResetPortals() {
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
	}
}
