using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineThickness : MonoBehaviour
{

	[SerializeField]
	float lineThickness = 0.5f;

    void Update()
    {
		for (int i = 0; i < GameObject.FindObjectsOfType<LineRenderer> ().Length; i++) {
			GameObject.FindObjectsOfType<LineRenderer> ()[i].widthMultiplier = lineThickness;
		}
    }
}
