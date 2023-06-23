using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourShow : MonoBehaviour
{
    void Update()
    {
		GetComponent<Graphic> ().color = Color.Lerp (Color.cyan, Color.gray, Mathf.PingPong (Time.time * 0.1f, 1)); 
    }
}
