using System;
using UnityEngine;
using UnityEngine.UI;

public class Spike : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.tag == "Saw")
				GameObject.FindObjectOfType<DeathScreen>().Activate("YOU HIT A SPINNING SAW!");
			else if (transform.IsChildOf(GameObject.FindGameObjectWithTag("LevelBottom").transform))
				GameObject.FindObjectOfType<DeathScreen>().Activate("YOU FELL OFF THE LEVEL!");
            else if (gameObject.tag == "Spikes")
				GameObject.FindObjectOfType<DeathScreen>().Activate("YOU HIT A SPIKE!");
        }   
    }
}