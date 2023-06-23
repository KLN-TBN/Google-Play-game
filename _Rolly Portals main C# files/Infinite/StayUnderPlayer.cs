using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StayUnderPlayer : MonoBehaviour
{
    void Update()
    {
		if (SceneManager.GetActiveScene ().name == "Infinite") {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				Vector2 newPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
				if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().velocity.y < -130)
					newPos.y = transform.position.y;
				else
					newPos.y = newPos.y - 500;
				transform.position = newPos;
			}
		} else {
			if (GameObject.FindGameObjectWithTag ("Player") != null)
				transform.position = new Vector2 (GameObject.FindGameObjectWithTag ("Player").transform.position.x, transform.position.y);
		}
    }
}
