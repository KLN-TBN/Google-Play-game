using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
		StartCoroutine (Self_Destruct ());
    }

	IEnumerator Self_Destruct() {
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
