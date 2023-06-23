using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnCollision : MonoBehaviour {

	private Explodable _explodable;
	[SerializeField]
	GameObject confetti;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Spikes" | col.gameObject.tag == "Saw") {
			_explodable.explode ();
			ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce> ();
			ef.doExplosion (transform.position);
		}
		else if (col.gameObject.tag == "Finish") {
			if (GameObject.FindObjectOfType<Window_Confetti> () == null) {
				confetti = Instantiate (confetti, GameObject.Find ("UI Overlay").transform);
				confetti.transform.SetSiblingIndex (0);
				if (GameObject.FindObjectOfType<LevelLoader> ().stage == 4)
					confetti.GetComponent<Window_Confetti> ().amount = 6;
				else
					confetti.GetComponent<Window_Confetti> ().amount = 2;
			}
		}
	}
}
