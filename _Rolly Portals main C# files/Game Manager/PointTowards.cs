using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowards : MonoBehaviour {

	[SerializeField]
	private GameObject target;

	void Update () {
		if (target.activeSelf) {
			Quaternion rotation = Quaternion.LookRotation (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
		}
	}
}
