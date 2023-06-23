using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalCoolDown : MonoBehaviour
{

	RectTransform fill;
	float coolDownSpeed = 9f;
	float fillWidth;
	[SerializeField]
	Sprite redBar;
	Sprite blueBar;
	[HideInInspector]
	public bool reachedMax;
	[HideInInspector]
	public float increaseDivider;

    void Start()
    {
		reachedMax = false;
		fill = transform.GetChild (0).GetComponent<RectTransform>();
		fillWidth = fill.sizeDelta.x;
		blueBar = fill.GetComponent<Image> ().sprite;
    }
		
    void FixedUpdate()
    {
		if (! GameObject.FindObjectOfType<Pause>().paused)
			fill.localPosition = new Vector2 (fill.localPosition.x - coolDownSpeed, fill.localPosition.y);
		if (fill.localPosition.x > 0) {
			fill.localPosition = new Vector2 (0, fill.localPosition.y);
			ReachMax ();
		}
		else if (fill.localPosition.x < -fillWidth)
			fill.localPosition = new Vector2 (-fillWidth, fill.localPosition.y);
		if (fill.localPosition.x == -fillWidth)
			Reset ();
    }

	public void FillIncrease(){
		if (increaseDivider < 0.1f)
			increaseDivider = 0.1f;
		fill.localPosition = new Vector2 (fill.localPosition.x + fillWidth/increaseDivider, fill.localPosition.y);
	}

	void ReachMax() {
		fill.GetComponent<Image> ().sprite = redBar;
		reachedMax = true;
	}

	public void Reset() {
		fill.GetComponent<Image> ().sprite = blueBar;
		reachedMax = false;
		fill.localPosition = new Vector2 (-fillWidth, fill.localPosition.y);
	}
}
