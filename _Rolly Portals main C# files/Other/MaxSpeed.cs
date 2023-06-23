using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeed : MonoBehaviour
{
	int maxFallingSpeed = -19;
	GameObject player;

	void Start() {
		transform.localScale = new Vector3 (1.2f, 1.2f, 1);
		maxFallingSpeed += (10 - Mathf.RoundToInt(GameObject.FindObjectOfType<Camera> ().orthographicSize)) * 2;
	}

    void Update()
    {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			player = GameObject.FindGameObjectWithTag ("Player");
			if (player.GetComponent<Rigidbody2D> ().velocity.y < maxFallingSpeed)
				player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (player.GetComponent<Rigidbody2D> ().velocity.x, maxFallingSpeed);
		}
    }
}
