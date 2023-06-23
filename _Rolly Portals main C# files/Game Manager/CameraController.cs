using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private bool followX = true;
    [SerializeField]
    private bool followY = true;
    //[SerializeField]
    public float xOffset = 0;
    [SerializeField]
    private float yOffset = 0;
    [SerializeField]
    private float speed = 0.1f;
    private GameObject player;

	void Start() {
		if (GameObject.FindWithTag ("Player") != null) {
			player = GameObject.FindWithTag("Player");
			Vector3 newPos = player.transform.position;
			newPos.x += xOffset;
			newPos.y += yOffset;
			newPos.z = -10;
			transform.position = newPos;
		}
	}
		
    void FixedUpdate ()
	{
		transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
		//print (player);
		if (player == null)
			player = GameObject.FindWithTag ("Player");
		else if (player.activeInHierarchy == true) {
			if (followX && followY) {
				Vector3 newPos = player.transform.position;
				MoveCamera (newPos);
			} else if (followX) {
				Vector3 newPos = player.transform.position;
				newPos.y = transform.position.y;
				MoveCamera (newPos);
			} else if (followY) {
				Vector3 newPos = player.transform.position;
				newPos.x = transform.position.x;
				MoveCamera (newPos);
			}
		}

		if (player != null){
			if (SceneManager.GetActiveScene ().name == "Infinite" & player.activeInHierarchy == true) {
				float velocity = 0;
				float newSize = (Mathf.Abs (player.GetComponent<Rigidbody2D> ().velocity.x) * Mathf.Abs (player.GetComponent<Rigidbody2D> ().velocity.y)) / 5;
				if (newSize < 8)
					newSize = 8;
				if (newSize > 25)
					newSize = 25;
				GetComponent<Camera> ().orthographicSize = Mathf.SmoothDamp (GetComponent<Camera> ().orthographicSize, newSize, ref velocity, 0.2f, 40);
			}
		}
    }

    void MoveCamera(Vector3 newPos)
    {
        newPos.x += xOffset;
        newPos.y += yOffset;
        newPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, newPos, speed);
    }
}
