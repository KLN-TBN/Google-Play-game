using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrinkAnimation : MonoBehaviour {

    public float maxSize = 2.0f;
    public float minSize = 0.2f;
    public float speed = 1.0f;

    void Update()
    {
		if (!transform.parent.GetComponent<Animation> ().isPlaying) {
			float range = maxSize - minSize;
			gameObject.GetComponent<RectTransform>().localScale = new Vector2(minSize + Mathf.PingPong(Time.time * speed, range), minSize + Mathf.PingPong(Time.time * speed, range));
		}
    }
}
