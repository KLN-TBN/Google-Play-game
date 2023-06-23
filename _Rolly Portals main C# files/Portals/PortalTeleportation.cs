using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
			if (collision.CompareTag("Player"))
			{
				int index;
				if (transform.GetSiblingIndex () == 0)
					index = 1;
				else
					index = 0;
				if (transform.parent.GetChild (index).gameObject.activeSelf) {
					collision.transform.position = transform.parent.GetChild(index).transform.position;
					gameObject.SetActive (false);
					transform.parent.GetChild (index).gameObject.SetActive (false);
				}
			}
    }
}
