using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimationsAndSounds : MonoBehaviour {

    [SerializeField]
    private GameObject portalDissapearPuff;
    [SerializeField]
    private AudioClip puffSound;
    [SerializeField]
    private AudioClip placeSound;

    private void OnEnable()
    {
		GetComponentInChildren<Animation>().Play("PortalPlace");
		GetComponentInChildren<Animation>().PlayQueued("PortalSpinning");
		GetComponentInChildren<AudioSource> ().PlayOneShot (placeSound);
    }

    private void OnDisable()
    {
		Instantiate(portalDissapearPuff, transform.GetChild(transform.childCount - 1).position, Quaternion.Euler(Vector3.zero));
		GetComponentInChildren<AudioSource> ().PlayOneShot (puffSound);
    }
}
